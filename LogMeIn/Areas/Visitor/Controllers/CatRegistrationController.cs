using System.Web.Mvc;
using LogMeIn.Controllers;
using LogMeIn.Data.Repositories.IRepositories;
using LogMeIn.Models;
using LogMeIn.Models.Models;
using LogMeIn.Models.ViewModels;
using LogMeIn.Utility;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.EntityFrameworkCore;
using Tests;

namespace LogMeIn.Areas.Visitor.Controllers;

[Area("Visitor")]
[Authorize]
public class CatRegistrationController : CatHelper
{
    private readonly ICompositeViewEngine _compositeViewEngine;
    private readonly IEmailSender _emailSender;

    public CatRegistrationController(IUnitOfWork unitOfWork, IEmailSender emailSender,
        ICompositeViewEngine compositeViewEngine) : base(unitOfWork)
    {
        _emailSender = emailSender;
        _compositeViewEngine = compositeViewEngine;
    }

    public async Task<IActionResult> ResolvePage(int index, int catRegistrationId, bool editing)
    {
        var value = UnitOfWork.CatRegistration.Get(x => x.Id == catRegistrationId, x => x.Cat).Cat.IsHomeCat;
        if (!value)
            return index switch
            {
                0 => RedirectToAction("UpsertCat", new { catRegistrationId, editing }),
                1 => RedirectToAction("UpsertParent", new { catRegistrationId, editing, gender = Gender.Male }),
                2 => RedirectToAction("UpsertParent", new { catRegistrationId, editing, gender = Gender.Female }),
                3 => RedirectToAction("UpsertExhibition", new { catRegistrationId, editing }),
                4 => RedirectToAction("Summary", new { catRegistrationId, editing }),
                _ => RedirectToAction("Index", "ExhibitionHome", new { id = catRegistrationId, editing })
            };

        return index switch
        {
            0 => RedirectToAction("UpsertCat", new { catRegistrationId, editing }),
            1 => RedirectToAction("UpsertExhibition", new { catRegistrationId, editing }),
            2 => RedirectToAction("Summary", new { catRegistrationId, editing }),
            _ => RedirectToAction("Index", "ExhibitionHome", new { id = catRegistrationId, editing })
        };
    }


    public async Task<IActionResult> CreateCatRegistration()
    {
        //volá si uživatel
        var personRegistration =
            UnitOfWork.PersonRegistration.Get(
                u => u.ExhibiterId == GetUserId() && u.ExhibitionId == _exhibitionId);
        if (personRegistration != null)
        {
            var val = UnitOfWork.OrderRepository.Get(x => x.PersonRegistrationId == personRegistration.Id);
            if (val != null)
            {
                TempData["error"] = "Už jste zaregistrovaní.";
                return RedirectToAction("Index", "Home");
            }
        }

        if (personRegistration is not { Draft: false })
        {
            var id = GetOrCreatePersonRegistration(GetUserId());
            return RedirectToAction("PersonRegistration", new { PersonRegistrationId = id });
        }


        var catRegistration = CreateNewCatRegistration(GetUserId());

        return RedirectToAction(nameof(UpsertCat),
            new
            {
                catRegistrationId = catRegistration.Id
            });
    }

    // public IActionResult GetCatReghistration(int id, bool? editing)
    // {
    //     // TODO validace
    //     var catRegistration = GetVaCatRegi(id);
    //     if (catRegistration == null)
    //         throw new Exception("");
    //     return RedirectToAction(nameof(UpsertCat),
    //         new
    //         {
    //             id = catRegistration.Id
    //         });
    // }

    private void verifyPersonRegistration(int PersonRegistrationId)
    {
        if (User.IsInRole(Roles.RoleAdmin.ToString()))
            return;
        var personRegistration = UnitOfWork.PersonRegistration.Get(x => x.Id == PersonRegistrationId);
        if (personRegistration == null)
            throw new InvalidOperationException("Person registration not found");
        if (personRegistration.ExhibiterId != GetUserId())
            throw new InvalidOperationException("You are not allowed to do this");

        var order = UnitOfWork.OrderRepository.Get(x => x.PersonRegistrationId == personRegistration.Id);
        if (order != null)
            throw new Exception("This was already submited");
    }

    public async Task<IActionResult> PersonRegistration(int PersonRegistrationId)
    {
        verifyPersonRegistration(PersonRegistrationId);
        var mapper4 = new PersonMapper(UnitOfWork);
        var x = mapper4.ConvertToDto(PersonRegistrationId);

        // if (x.Item2)
        //     throw new InvalidOperationException("ALready saved");

        return View("PersonRegistration", x.Item1);
    }

    [Microsoft.AspNetCore.Mvc.HttpPost]
    public async Task<IActionResult> PersonRegistration(ModelVm vm)
    {
        verifyPersonRegistration(vm.PersonRegistrationId);
        PersonMapper mapper = new(UnitOfWork);
        mapper.save(vm.PersonRegistrationId, vm);
        return RedirectToAction("CreateCatRegistration");
    }


    [Microsoft.AspNetCore.Mvc.HttpPost]
    public async Task<IActionResult> UpsertCat(ExhibitedCatVm vm)
    {
        Verify(vm.CatRegistrationId, vm.StepId);

        vm.DateOfBirth = vm.DateOfBirth.AddHours(12).ToUniversalTime();
        if (!VerifyVal(vm.BreederName, vm.IsSameAsExhibitor))
            ModelState.AddModelError("BreederName", "Jméno chovatele je povinné");
        if (!VerifyVal(vm.BreederSurname, vm.IsSameAsExhibitor))
            ModelState.AddModelError("BreederSurname", "Přijmení chovatele je povinné");
        if (!VerifyVal(vm.BreederCountry, vm.IsSameAsExhibitor))
            ModelState.AddModelError("BreederCountry", "Země chovatele je povinná");
        if (!VerifyGroupVal(vm.Group, vm.Ems))
            ModelState.AddModelError("Group", "Problém se skupinou");
        if (!VerifyBreedingBookBool(vm.BreedingBook, vm.DateOfBirth))
            ModelState.AddModelError("BreedingBook",
                "Kočka je starší než 6 měsíců a musí mít číslo plemenné knihy");

        if (!ModelState.IsValid) return View("ExhibitedCat", vm);

        var mapper = new ExhibitedCatMapper(UnitOfWork);

        var catReistration = UnitOfWork.CatRegistration.Get(x => x.Id == vm.CatRegistrationId);
        catReistration.LastStep = vm.StepId;
        UnitOfWork.CatRegistration.Update(catReistration);
        UnitOfWork.Save();
        mapper.SaveVm(vm);

        return await ResolvePage(vm.StepId + 1, vm.CatRegistrationId, vm.editting);
    }

    public async Task<IActionResult> UpsertCat(int catRegistrationId, bool? editing)
    {
        Verify(catRegistrationId, 0);
        TempData["warning"] = "/api/ems_e";

        var Mapper = new ExhibitedCatMapper(UnitOfWork);
        var exhibitedCatVm = Mapper.getAsVm(catRegistrationId);

        return View("ExhibitedCat", exhibitedCatVm);
    }

    public async Task<IActionResult> UpsertParent(int catRegistrationId, bool? editing, Gender gender)
    {
        Verify(catRegistrationId, 0);

        TempData["warning"] = "/api/ems_p";
        var Mapper2 = new ParentMapper(UnitOfWork);
        var stepVm = Mapper2.ConvertToDto(catRegistrationId, gender);
        return View("CatRegistration", stepVm);
    }

    private async Task Invoice(int personRegistrationId)
    {
        // validation is not necessary as it  is a private method

        Converter converter = new(_emailSender);

        // var personRes = _compositeViewEngine.FindView(ControllerContext, "Person", false);
        // if (personRes.View == null) throw new ArgumentNullException("Person", "View not found");
        var mapper = new PersonMapper(UnitOfWork);
        var personVm = mapper.ConvertToDto(personRegistrationId).Item1;
        personVm.Disabled = true;
        // await converter.Invoice(personRes.View, x, ControllerContext, TempData, "ondrejman1@gmail.com",
        //     "Registrace uživatele " + personRegistrationId);

        var catregistrations = UnitOfWork.PersonRegistration.GetAsQuery(x => x.Id == personRegistrationId)
            .Include(x => x.CatRegistrations)
            .AsEnumerable()
            .SelectMany(x => x.CatRegistrations)
            .Select(x => x.Id).AsEnumerable();

        var helper = new Helper1(UnitOfWork);

        List<AdminVm> Get = new();
        foreach (var sth in catregistrations) Get.Add(helper.Cat(sth));


        // foreach (var catregId in catregistrations)
        // {
        //     var viewResult = _compositeViewEngine.FindView(ControllerContext, "Cat", false);
        //     if (viewResult.View == null) throw new ArgumentNullException("View", "View not found");
        //     var z = helper.Cat(catregId);
        //     await converter.Invoice(viewResult.View, z, ControllerContext, TempData, "ondrejman1@gmail.com",
        //         "Registrace uživatele " + personRegistrationId);
        // }

        var InvoiceVm = new InvoiceVm
        {
            PersonVm = personVm,
            CatRegistrations = Get
        };

        foreach (var registration in InvoiceVm.CatRegistrations)
        {
            var list = registration.Exhibition.Groups.ToList();

            var newList = list
                .Where(item => registration.Exhibition.SelectedId
                    .ToHashSet()
                    .Contains(item.Value))
                .ToList();
            registration.Exhibition.Groups = newList;
        }

        var viewResult = _compositeViewEngine.FindView(ControllerContext, "Email", false);
        if (viewResult.View == null) throw new ArgumentNullException("Email", "View not found");
        await converter.Invoice(viewResult.View, InvoiceVm, ControllerContext, TempData, "ondrejman1@gmail.com",
            "Registrace uživatele " + personRegistrationId);
        await converter.Invoice(viewResult.View, InvoiceVm, ControllerContext, TempData, "Sabrina.Oralkova@gmail.com",
            "Registrace uživatele " + personRegistrationId);
    }

    [Microsoft.AspNetCore.Mvc.HttpPost]
    public async Task<IActionResult> UpsertParent(CatVm vm)
    {
        Verify(vm.CatRegistrationId, vm.StepId);
        if (!ModelState.IsValid) return View("CatRegistration", vm);

        var parentMapper = new ParentMapper(UnitOfWork);
        parentMapper.SaveModel(vm);

        var catReistration = UnitOfWork.CatRegistration.Get(x => x.Id == vm.CatRegistrationId);
        catReistration.LastStep = vm.StepId;
        UnitOfWork.CatRegistration.Update(catReistration);
        UnitOfWork.Save();

        return await ResolvePage(vm.StepId + 1, vm.CatRegistrationId, vm.editting);
    }

    public async Task<IActionResult> UpsertExhibition(int catRegistrationId, bool editing)
    {
        var mapper = new ExhibitionMapper(UnitOfWork);
        var x = mapper.ConvertToDto(catRegistrationId);
        Verify(catRegistrationId, x.StepId);

        return View("Exhibition", x);
    }

    [Microsoft.AspNetCore.Mvc.HttpPost]
    public async Task<IActionResult> UpsertExhibition(ExhibitionVm vm)
    {
        Verify(vm.CatRegistrationId, vm.StepId);
        var mappper = new ExhibitionMapper(UnitOfWork);
        var catRegistration = mappper.GetCatRegistration(vm.CatRegistrationId);

        if (catRegistration == null)
            throw new Exception("");

        if (vm.AttendanceOnDays.Select(x => x[0]).Where(x => x.IsChecked).Count() <= 0)
            ModelState.AddModelError("AttendanceOnDays", "Musíte vybrat alespoň jeden den");
        if (!ModelState.IsValid)
        {
            var vm1 = mappper.HandleSHit(vm, catRegistration); // TODO handle vm correctly
            return await UpsertExhibition(vm.CatRegistrationId, vm.editting);
        }

        mappper.SaveModel(vm, catRegistration);
        return await ResolvePage(vm.StepId + 1, vm.CatRegistrationId, vm.editting);
    }

    public async Task<IActionResult> Summary(int catRegistrationId, bool? editing)
    {
        var catRegistration =
            UnitOfWork.CatRegistration.GetAsQuery(x => x.Id == catRegistrationId)
                .Include(x => x.PersonRegistration)
                .ThenInclude(x => x.Exhibiter)
                .Include(x => x.Cat)
                .ThenInclude(x => x.Father)
                .Include(x => x.Cat)
                .ThenInclude(x => x.Mother)
                .Include(x => x.Cat)
                .ThenInclude(x => x.Breeder)
                .FirstOrDefault();

        var stepVm = new StepVm<CatRegistration>();
        var price = new Prices(UnitOfWork, catRegistration.PersonRegistrationId);
        catRegistration.Price = price.getCatPrice(catRegistration.Id);
        stepVm.Data = catRegistration;

        stepVm.StepId = catRegistration.Cat.IsHomeCat ? 2 : 4;
        stepVm.RegistrationId = catRegistration.Id;
        Verify(catRegistrationId, stepVm.StepId);
        return View("Summary", stepVm);
    }

    [Microsoft.AspNetCore.Mvc.HttpPost]
    public async Task<IActionResult> Summary(StepVm<CatRegistration> vm)
    {
        Verify(vm.RegistrationId, vm.StepId);
        // if (!ModelState.IsValid) return View("Summary", vm);

        var item = UnitOfWork.CatRegistration.Get(x => x.Id == vm.RegistrationId);
        item.LastStep = vm.StepId++;
        UnitOfWork.CatRegistration.Update(item);

        UnitOfWork.Save();

        if (User.IsInRole(Roles.RoleAdmin.ToString()))
            return RedirectToAction("Cat", new { catRegistrationId = item.Id });
        return RedirectToAction("NextOrPay", new { personRegID = item.PersonRegistrationId });
    }


    public async Task<IActionResult> PayInformation(int personRegistrationId)
    {
        verifyPersonRegistration(personRegistrationId);
        var personRegistration = UnitOfWork.PersonRegistration.GetAsQuery(x => x.Id == personRegistrationId)
            .Include(x => x.Exhibiter)
            .Include(x => x.CatRegistrations)
            .ThenInclude(x => x.Cat)
            .FirstOrDefault();
        var mapper = new Prices(UnitOfWork, personRegistrationId);

        var x = new List<VelkyVm>();
        foreach (var catRegistration in personRegistration.CatRegistrations.Where(x => x.isDraft(x.Cat.IsHomeCat)))
            x.Add(new VelkyVm(catRegistration.Cat.Name + ", " + catRegistration.Cat.PedigreeNumber,
                mapper.getCatPrice(catRegistration.Id), catRegistration.Id));

        var price1 = mapper.getTotalPices(personRegistrationId);

        var payInfoVm = new PayInfoVm
        {
            cats = x,
            person = new VelkyVm("Poplatky za propagaci", mapper.getPersonEnumPricer(), personRegistration.Id),
            TotalPrice = price1,
            PersonRegID = personRegistration.Id
        };

        payInfoVm.Messahge = personRegistration.Id + "," + personRegistration.Exhibiter.PhoneNumber + "," +
                             personRegistration.Exhibiter.Email;

        return View(payInfoVm);
    }


    [Microsoft.AspNetCore.Mvc.HttpPost]
    public async Task<IActionResult> PayInformation(PayInfoVm vm)
    {
        verifyPersonRegistration(vm.PersonRegID);
        var personRegistration = UnitOfWork.PersonRegistration.GetAsQuery(x => x.Id == vm.PersonRegID)
            .Include(x => x.Exhibiter)
            .Include(x => x.CatRegistrations)
            .ThenInclude(x => x.Cat)
            .FirstOrDefault();
        var mapper = new Prices(UnitOfWork, vm.PersonRegID);

        var val = UnitOfWork.OrderRepository.Get(x => x.PersonRegistrationId == personRegistration.Id);
        if (val != null)
        {
            TempData["error"] = "Objednávka byla dokončena, nelze ji znovu odeslat";
            return RedirectToAction("Index", "Home");
        }
        // throw new InvalidOperationException("Order already exists"); //todo 

        var price1 = mapper.getTotalPices(vm.PersonRegID);

        var order = new Order
        {
            PersonRegistrationId = personRegistration.Id,
            Price = price1,
            Submitted = DateTime.Now.ToUniversalTime()
        };
        UnitOfWork.OrderRepository.AddAndSave(order);

        TempData["Success"] = "Vaši registraci jsme přijali";
        Invoice(vm.PersonRegID);
        return RedirectToAction("Index", "Home");
    }

    public async Task<IActionResult> Cat(int catRegistrationId)
    {
        Verify(catRegistrationId, -1);
        var helper = new Helper1(UnitOfWork);
        var x = helper.Cat(catRegistrationId);
        return View(x);
    }

    public async Task<IActionResult> DeleteCatReg(int catRegistrationId)
    {
        Verify(catRegistrationId, -1);

        var x = UnitOfWork.CatRegistration.Get(x => x.Id == catRegistrationId, x => x.PersonRegistration);
        var x1 = x.PersonRegistration;

        DeleteCOntroller deleteCOntroller = new(UnitOfWork);
        deleteCOntroller.DeleteCatRegistration(catRegistrationId);
        UnitOfWork.Save();

        TempData["Success"] = "Registrace kočky byla smazána";
        return RedirectToAction("PayInformation", new { personRegistrationId = x1.Id });
    }

    public async Task<IActionResult> DeletePerson(int catRegistrationId)
    {
        verifyPersonRegistration(catRegistrationId);
        DeleteCOntroller deleteCOntroller = new(UnitOfWork);

        if (User.IsInRole(Roles.RoleAdmin.ToString()))
        {
            var x = UnitOfWork.OrderRepository.Get(x => x.PersonRegistrationId == catRegistrationId);
            if (x != null)
                deleteCOntroller.deleteOrder(x.Id);
            else
                deleteCOntroller.DeletePersonReg(catRegistrationId);
        }
        else
        {
            deleteCOntroller.DeletePersonReg(catRegistrationId);
        }

        UnitOfWork.Save();
        TempData["Success"] = "Registrace uživatele byla úspěšně smazána";
        return RedirectToAction("Index", "Home");
    }


    public async Task<IActionResult> NextOrPay(int personRegID)
    {
        verifyPersonRegistration(personRegID);
        return View(personRegID);
    }

    public async Task<IActionResult> Person(int catRegistrationId)
    {
        verifyPersonRegistration(catRegistrationId);

        var mapper = new PersonMapper(UnitOfWork);
        var x = mapper.ConvertToDto(catRegistrationId).Item1;
        x.Disabled = true;
        return View(x);
    }

    public async Task<IActionResult> PersonEdit(int personRegId)
    {
        verifyPersonRegistration(personRegId);
        var mapper4 = new PersonMapper(UnitOfWork);
        var x = mapper4.ConvertToDto(personRegId);

        // if (x.Item2)
        //     throw new InvalidOperationException("ALready saved");

        return View("PersonEdit", x.Item1);
    }

    [Microsoft.AspNetCore.Mvc.HttpPost]
    public async Task<IActionResult> PersonEdit(ModelVm vm)
    {
        verifyPersonRegistration(vm.PersonRegistrationId);
        PersonMapper mapper = new(UnitOfWork);
        mapper.save(vm.PersonRegistrationId, vm);
        if (User.IsInRole(Roles.RoleAdmin.ToString()))
            return RedirectToAction("PersonReg", new { catRegistrationId = vm.PersonRegistrationId });

        return RedirectToAction("PayInformation", new { personRegistrationId = vm.PersonRegistrationId });
    }

    public async Task<IActionResult> PersonReg(int catRegistrationId)
    {
        verifyPersonRegistration(catRegistrationId);
        var x1 = UnitOfWork.PersonRegistration.Get(x => x.Id == catRegistrationId, x => x.Exhibiter);
        if (x1 == null || (x1.ExhibiterId != GetUserId() && !User.IsInRole(Roles.RoleAdmin.ToString())))
            throw new InvalidOperationException("You are not allowed to do this");

        var mapper = new PersonMapper(UnitOfWork);
        var x = mapper.ConvertToDto(catRegistrationId).Item1;
        x.Disabled = true;
        return View(x);
    }


    [Microsoft.AspNetCore.Mvc.HttpPost]
    [Microsoft.AspNetCore.Mvc.AcceptVerbs("GET", "POST")]
    public IActionResult VerifySurname(string breederSurname, bool isSameAsExhibitor)
    {
        if (isSameAsExhibitor || !string.IsNullOrEmpty(breederSurname))
            return Json(true);
        return Json("Toto pole je povidnné");
    }


    [Microsoft.AspNetCore.Mvc.AcceptVerbs("GET", "POST")]
    public IActionResult VerifyBreederSurname(string breederSurname, bool isSameAsExhibitor)
    {
        return Verify(breederSurname, isSameAsExhibitor);
    }

    [Microsoft.AspNetCore.Mvc.AcceptVerbs("GET", "POST")]
    public IActionResult VerifyBreederCountry(string breederCountry, bool isSameAsExhibitor)
    {
        return Verify(breederCountry, isSameAsExhibitor);
    }

    [Microsoft.AspNetCore.Mvc.AcceptVerbs("GET", "POST")]
    public IActionResult VerifyBreederName(string breederName, bool isSameAsExhibitor)
    {
        return Verify(breederName, isSameAsExhibitor);
    }

    [Microsoft.AspNetCore.Mvc.AcceptVerbs("GET", "POST")]
    public IActionResult VerifyGroup(int? group, string ems)
    {
        var x = ems.ToLower();
        if (x.Contains("rag ") || x.Contains("mc "))
        {
            if (group == null)
                return Json("Toto pole je povinné");
            return Json(true);
        }

        if (group is null)
            return Json(true);
        return Json("TThis cannot be filled");
    }

    public bool VerifyGroupVal(int? value, string ems)
    {
        var x = ems.ToLower();
        if (x.Contains("rag ") || x.Contains("mc "))
        {
            if (value == null)
                return false;
            return true;
        }

        if (value is null)
            return true;
        return false;
    }

    private bool VerifyBreedingBookBool(string BreedingBook, DateTime DateOfBirth)
    {
        if (!string.IsNullOrEmpty(BreedingBook))
            return true;
        return DateOfBirth.AddMonths(6) > DateTime.Now;
    }

    [Microsoft.AspNetCore.Mvc.AcceptVerbs("GET", "POST")]
    public IActionResult VerifyBreedingBook(string BreedingBook, DateTime DateOfBirth)
    {
        return !VerifyBreedingBookBool(BreedingBook, DateOfBirth)
            ? Json("Kočka starší než 6 měsíců a potřebuje číslo plemenné knihy")
            : Json(true);
    }

    [Microsoft.AspNetCore.Mvc.HttpPost]
    [Microsoft.AspNetCore.Mvc.Route("api/ems_e")]
    public IActionResult MyEndpoint(ExhibitedCatVm formData)
    {
        if (formData == null)
            throw new ArgumentNullException();
        if (string.IsNullOrEmpty(formData.Ems)) return BadRequest(new { message = "Ems kód je ve špatném formátu" });
        var emsServcie = new EmsService(formData.Ems);
        if (!emsServcie.canBeParsed()) return BadRequest(new { message = "Ems kód je ve špatném formátu" });
        if (!emsServcie.Parse().Contains(formData.Breed + " " + formData.Colour))
            return BadRequest(new { message = "Ems kód se neshoduje s plemenem a barvou" });

        return Ok(new { message = "Success!" });
    }

    [Microsoft.AspNetCore.Mvc.HttpPost]
    [Microsoft.AspNetCore.Mvc.Route("api/ems_p")]
    public IActionResult MyEndpoint([FromBody] CatVm formData)
    {
        if (string.IsNullOrEmpty(formData.Ems)) return BadRequest(new { message = "Ems kód je ve špatném formátu" });
        var emsServcie = new EmsService(formData.Ems);
        if (!emsServcie.canBeParsed()) return BadRequest(new { message = "Ems kód je ve špatném formátu" });
        if (!emsServcie.Parse().Contains(formData.Breed + " " + formData.Colour))
            return BadRequest(new { message = "Ems kód se neshoduje s plemenem a barvou" });

        return Ok(new { message = "Success!" });
    }

    public class InvoiceVm
    {
        public ModelVm PersonVm { get; set; }
        public List<AdminVm> CatRegistrations { get; set; }
    }
}