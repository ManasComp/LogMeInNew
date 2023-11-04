using System.Text.Json;
using LogMeIn.Controllers;
using LogMeIn.Data.Repositories.IRepositories;
using LogMeIn.Models.Models;
using LogMeIn.Models.ViewModels;
using LogMeIn.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;
using JsonSerializer1 = Newtonsoft.Json.JsonSerializer;

namespace LogMeIn.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = nameof(Roles.RoleAdmin))]
public class RegistrationController : GController
{
    public RegistrationController(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    private string GetTitle(Cat cat)
    {
        if (!string.IsNullOrEmpty(cat.TitleBeforeName) && !string.IsNullOrEmpty(cat.TitleAfterName))
            return cat.TitleBeforeName + " " + cat.TitleAfterName;

        return cat.TitleBeforeName + cat.TitleAfterName;
    }

    private IBreeder getBreeder(CatRegistration catRegistration)
    {
        return catRegistration.Cat.IsHomeCat
            ? catRegistration.PersonRegistration.Exhibiter
            : catRegistration.Cat.Breeder;
    }

    // GET
    public IActionResult Index()
    {
        var catRegistrations =
            UnitOfWork.OrderRepository.GetAsQuery(x => true)
                .Include(x => x.PersonRegistration)
                .ThenInclude(x => x.Exhibiter)
                .Include(x => x.PersonRegistration)
                .ThenInclude(x => x.CatRegistrations)
                .ThenInclude(x => x.Cat)
                .ToList();


        var zaznamy = catRegistrations
            .Select(registration =>
                new RecordVm
                {
                    Submitted = registration.Submitted.ToString(),
                    Name = registration.PersonRegistration.Exhibiter.FirstName,
                    Surname = registration.PersonRegistration.Exhibiter.LastName,
                    email = registration.PersonRegistration.Exhibiter.Email,
                    phone = registration.PersonRegistration.Exhibiter.PhoneNumber,
                    paid = registration.OrderStatus == OrderStatus.Paid, //TODO
                    NumberOFcats = registration.PersonRegistration
                        .getNotDraftCatRegistrations(registration.PersonRegistration.CatRegistrations).Count,
                    Id = registration.Id
                }).ToList();

        return View(zaznamy);
    }

    private JsonVm.BreederInfo ReturnBreederInfo(CatRegistration registration)
    {
        if (registration.Cat.IsSameAsExhibitor)
            return new JsonVm.BreederInfo(
                registration.PersonRegistration.Exhibiter.FirstName,
                registration.PersonRegistration.Exhibiter.LastName,
                registration.PersonRegistration.Exhibiter.Country
            );

        return new JsonVm.BreederInfo(
            registration.Cat.Breeder.FirstName,
            registration.Cat.Breeder.LastName,
            registration.Cat.Breeder.Country
        );
    }

    public List<CatRegistration> jsons()
    {
        var orderReg = UnitOfWork.OrderRepository
            .GetAsQuery().Include(x => x.PersonRegistration)
            .ThenInclude(x => x.CatRegistrations)
            .ThenInclude(x => x.Cat)
            .Select(x => x.PersonRegistration)
            .ToList()
            .SelectMany(x => x.getNotDraftCatRegistrations(x.CatRegistrations))
            .Select(x => x.Id).ToHashSet();

        var catRegistrations =
            UnitOfWork.CatRegistration.GetAsQuery(x => orderReg.Contains(x.Id))
                .Include(x => x.CompleteFees)
                .AsNoTracking()
                .Include(x => x.AttendanceOnDays)
                .ThenInclude(x => x.DayFees)
                .ThenInclude(x => x.Fee)
                .AsNoTracking()
                .Include(x => x.PersonRegistration)
                .ThenInclude(x => x.CompleteFees)
                .AsNoTracking()
                .Include(x => x.PersonRegistration)
                .ThenInclude(x => x.PersonEnumFee)
                .Include(x => x.PersonRegistration)
                .ThenInclude(x => x.Exhibition)
                .ThenInclude(x => x.Price)
                .ThenInclude(x => x.ExhibitedGroup)
                .Include(x => x.SelectedGroups)
                .AsNoTracking()
                .Include(x => x.Cat)
                .ThenInclude(x => x.Mother)
                .Include(x => x.Cat)
                .ThenInclude(x => x.Father)
                .Include(x => x.PersonRegistration)
                .ThenInclude(x => x.Exhibiter)
                .Include(x => x.Cat)
                .ThenInclude(x => x.Breeder).AsNoTracking()
                .ToList();


        return catRegistrations;
    }

    private RootObject getRoot()
    {
        var catRegistrations = jsons();
        var root = new RootObject((
            from registration in catRegistrations
            let mother = registration.Cat.Mother
            let father = registration.Cat.Father
            let exhibitor = registration.PersonRegistration.Exhibiter
            let cat = registration.Cat
            let exhibition = registration.SelectedGroups.Select(x => x.GroupId).ToList()
            let exhibitedClass = string.Join(";", exhibition)
            let breeder = getBreeder(registration)
            select new JsonVm.ShowInfo(
                exhibitedClass,
                cat.Group,
                registration.Note,
                new JsonVm.Animal(
                    cat.Name,
                    GetTitle(cat),
                    cat.Ems,
                    cat.Breed,
                    cat.Colour,
                    cat.PedigreeNumber,
                    cat.Sex.ToString(),
                    cat.BirthDate.ToString("yyyy-MM-dd"),
                    cat.Neutered,
                    new JsonVm.ParentInfo(
                        mother.Name,
                        GetTitle(mother),
                        mother.Ems,
                        breed: mother.Breed,
                        color: mother.Colour,
                        pedigreeNumber: mother.PedigreeNumber
                    ),
                    new JsonVm.ParentInfo(
                        father.Name,
                        GetTitle(father),
                        father.Ems,
                        breed: father.Breed,
                        color: father.Colour,
                        pedigreeNumber: father.PedigreeNumber
                    ),
                    ReturnBreederInfo(registration)
                ),
                new JsonVm.ExhibitorInfo(
                    exhibitor.FirstName,
                    exhibitor.LastName,
                    exhibitor.PhoneNumber,
                    exhibitor.Email,
                    exhibitor.Street,
                    exhibitor.HouseNumber,
                    exhibitor.City,
                    exhibitor.ZipCode,
                    exhibitor.Country,
                    exhibitor.Organization,
                    exhibitor.MemberNumber,
                    exhibitor.DateOfBirth > DateTime.Now.AddYears(-18)
                )
            )
        ).ToList());

        return root;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        JsonSerializer.SerializeToUtf8Bytes(getRoot(), options);
        return Ok(Json(new { data = getRoot() }));
    }

    [HttpGet]
    public IActionResult GetAllAsCsv()
    {
        var catRegistrations = jsons();
        var root = getRoot();

        if (root.Entries.Count == 0)
            return
                Ok(""); // Assuming this is an HTTP response, consider returning an appropriate status code like NotFound instead of an empty string.

        var headerJson = JsonConvert.SerializeObject(root.Entries[0]);
        var header = Helper.DeserializeAndFlatten(headerJson)
            .AsEnumerable()
            .Select(x => x.Key.ToString())
            .ToList();

        var rows = new List<List<string?>>();

        rows.Add(header);

        var registrationRows = root.Entries
            .Select(x => Helper.DeserializeAndFlatten(JsonConvert.SerializeObject(x))
                .AsEnumerable()
                .Select(x => x.Value is null ? "" : x.Value.ToString())
                .ToList());

        rows.AddRange(registrationRows);

        var csv = ExcelConverter.ConvertToCsv(rows);
        return Ok(csv);

        // var csvFilePath = "output.csv";
        // // Write the rows to the CSV file
        // using (var writer = new StreamWriter(csvFilePath))
        // {
        //     foreach (var csvLine in rows
        //                  .Select(row => string.Join(",", row)))
        //         writer.WriteLine(csvLine);
        // }
    }

    public IActionResult AllItemsByPersonReg(int personRegistrationId)
    {
        var x = UnitOfWork.PersonRegistration.Get(x => x.Id == personRegistrationId, y => y.Order).Order;
        if (x == null)
            throw new ArgumentException("Order is null");
        return RedirectToAction("AllItems", new { catRegistrationId = x.Id });
    }


    public IActionResult AllItems(int catRegistrationId)
    {
        var data = UnitOfWork.OrderRepository.GetAsQuery(x => x.Id == catRegistrationId)
            .Include(x => x.PersonRegistration)
            .ThenInclude(x => x.CatRegistrations)
            .ThenInclude(x => x.Cat)
            .Include(x => x.PersonRegistration)
            .ThenInclude(x => x.Exhibiter)
            .Include(x => x.PersonRegistration)
            .ThenInclude(x => x.Exhibition)
            .FirstOrDefault();


        var personRegistration = data.PersonRegistration;

        var mapper = new Prices(UnitOfWork, personRegistration.Id);
        var x = new List<VelkyVm>();
        foreach (var catRegistration in personRegistration.CatRegistrations.Where(x => x.isDraft(x.Cat.IsHomeCat)))
            x.Add(new VelkyVm(catRegistration.Cat.Name + ", " + catRegistration.Cat.PedigreeNumber,
                mapper.getCatPrice(catRegistration.Id), catRegistration.Id));

        var price1 = mapper.getTotalPices(catRegistrationId);

        var payInfoVm = new AdminPayInfo
        {
            cats = x,
            person = new VelkyVm("Poplatky za propagaci", mapper.getPersonEnumPricer(), personRegistration.Id),
            TotalPrice = price1,
            Order = data,
            PersonRegID = personRegistration.Id
        };


        return View(payInfoVm);
    }
}