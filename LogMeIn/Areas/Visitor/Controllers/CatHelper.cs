using System.Security.Claims;
using LogMeIn.Controllers;
using LogMeIn.Data.Repositories.IRepositories;
using LogMeIn.Models;
using LogMeIn.Models.Models;
using LogMeIn.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LogMeIn.Areas.Visitor.Controllers;

[Area("Visitor")]
public class CatHelper : GController
{
    public readonly int _exhibitionId;

    protected CatHelper(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        var exhibition = UnitOfWork.Exhibition.Get(x => true);
        if (exhibition == null)
            throw new Exception("");
        _exhibitionId = exhibition.Id;
    }

    public string GetUserId()
    {
        var claimsIdentity = (ClaimsIdentity?)User.Identity;
        if (claimsIdentity == null)
            throw new Exception("");
        var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (userId == null)
            throw new Exception("");
        return userId;
    }

    public int GetOrCreatePersonRegistration(string userID)
    {
        var userId = userID;
        var personRegistration =
            UnitOfWork.PersonRegistration.Get(
                u => u.ExhibiterId == userId && u.ExhibitionId == _exhibitionId);
        if (personRegistration != null)
            return personRegistration.Id;
        personRegistration = new PersonRegistration
        {
            ExhibitionId = _exhibitionId,
            ExhibiterId = userId
        };
        UnitOfWork.PersonRegistration.Add(personRegistration);
        UnitOfWork.Save();

        var exhibition = UnitOfWork.Exhibition.GetAsQuery(x => x.Id == _exhibitionId)
            .Include(y => y.Fees)
            .Include(x => x.EnumFees)
            .ThenInclude(x => x.FeeRecords).FirstOrDefault();
        if (exhibition == null)
            throw new Exception("");
        foreach (var fee in exhibition.Fees)
            switch (fee.Type)
            {
                case Types.DeyCat or Types.WholeCat:
                    //handle else
                    break;
                case Types.WholePerson:
                    var toStore3 =
                        new StoredFees<PersonRegistration, Fee, bool>(fee.Id, personRegistration.Id, fee.DefaultBought);
                    UnitOfWork.PersonFees.AddAndSave(toStore3);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

        foreach (var enumFee in exhibition.EnumFees)
        {
            var toStore3 = new StoredFees<PersonRegistration, EnumFee, int>(
                enumFee.Id,
                personRegistration.Id,
                enumFee.FeeRecords.FirstOrDefault(x => x.Default)?.Id ?? throw new Exception("ghghghhghhhg")
            );
            UnitOfWork.EnumFees.AddAndSave(toStore3);
        }

        return personRegistration.Id;
    }


    protected bool Verify(int catRegistration, int step)
    {
        var personRegistration = UnitOfWork.PersonRegistration.GetAsQuery(
                u => u.ExhibiterId == GetUserId() && u.ExhibitionId == _exhibitionId)
            .Include(x => x.CatRegistrations)
            .ThenInclude(x => x.Cat).FirstOrDefault();

        var catRegistration1 = personRegistration?.CatRegistrations.FirstOrDefault(x => x.Id == catRegistration);
        if (catRegistration1 == null && !User.IsInRole(Roles.RoleAdmin.ToString()))
            throw new Exception("You are not allowed to do this");


        // if (catRegistration1.canGoTo(step, catRegistration1.Cat.IsHomeCat))
        //     throw new Exception("Přeskakuješ");

        if (personRegistration != null)
        {
            var Order = UnitOfWork.OrderRepository.Get(x => x.PersonRegistrationId == personRegistration.Id);
            if (Order != null && !User.IsInRole(Roles.RoleAdmin.ToString()))
                throw new Exception("This was already submited");
        }

        return true;
    }


    private int GetOrCreateExhibvitedCat()
    {
        var father = new Cat();
        father.Sex = Gender.Male;
        UnitOfWork.Cat.AddAndSave(father);

        var mother = new Cat();
        mother.Sex = Gender.Female;
        UnitOfWork.Cat.AddAndSave(mother);

        var breeder = new Breeder();
        UnitOfWork.BreederRepository.AddAndSave(breeder);

        var cat = new ExhibitedCat
        {
            FatherId = father.Id,
            MotherId = mother.Id,
            BreederId = breeder.Id
            //date of birth is not set
        };
        UnitOfWork.ExhibitedCatRepository.AddAndSave(cat);
        return cat.Id;
    }

    protected DateTime[] GetDatesBetween(DateTime startDate, DateTime endDate)
    {
        return Enumerable.Range(0,
                1 + endDate.Subtract(startDate).Days)
            .Select(offset => startDate.AddDays(offset))
            .ToArray();
    }

    private void HandleFees(int catRegistrationId, int personRegistrationId)
    {
        var exhibition = UnitOfWork.Exhibition.GetAsQuery(x => x.Id == _exhibitionId)
            .Include(y => y.Fees)
            .Include(x => x.EnumFees)
            .ThenInclude(x => x.FeeRecords).FirstOrDefault();


        if (exhibition == null)
            throw new Exception("");

        var dates = GetDatesBetween(exhibition.StartDate, exhibition.EndDate);
        var set = new HashSet<int>();
        foreach (var date in dates)
        {
            var day = new Day<CatRegistration>(catRegistrationId, date);
            UnitOfWork.Day.AddAndSave(day);
            set.Add(day.Id);
        }

        foreach (var fee in exhibition.Fees)
            switch (fee.Type)
            {
                case Types.DeyCat:
                    foreach (var toStore1 in set
                                 .Select(dayId =>
                                     new StoredFees<Day<CatRegistration>, Fee, bool>(fee.Id, dayId, fee.DefaultBought)))
                        UnitOfWork.DayFees.AddAndSave(toStore1);
                    break;
                case Types.WholeCat:
                    var toStore2 =
                        new StoredFees<CatRegistration, Fee, bool>(fee.Id, catRegistrationId, fee.DefaultBought);
                    UnitOfWork.CatFees.AddAndSave(toStore2);
                    break;
                case Types.WholePerson:
                    //handle else
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
    }

    protected CatRegistration CreateNewCatRegistration(string customerUserID)
    {
        var personRegistrationId = GetOrCreatePersonRegistration(customerUserID);
        var catId = GetOrCreateExhibvitedCat();

        var x = UnitOfWork.CatRegistration.GetAll(x => x.PersonRegistrationId == personRegistrationId, "Cat");

        var catRegistration = new CatRegistration
        {
            CatId = catId,
            LastStep = 0,
            // SelectedGroups = new List<int> { 0 }.ToArray(), TODO
            PersonRegistrationId = personRegistrationId,
            CatOrder = x.Count(y => y.isDraft(y.Cat.IsHomeCat))
        };
        UnitOfWork.CatRegistration.AddAndSave(catRegistration);

        HandleFees(catRegistration.Id, personRegistrationId);

        return catRegistration;
    }

    protected bool VerifyVal(string? text, bool isSameAsExhivitoe)
    {
        return isSameAsExhivitoe || !string.IsNullOrEmpty(text);
    }

    protected JsonResult Verify(string text, bool isSameAsExhivitoe)
    {
        if (VerifyVal(text, isSameAsExhivitoe))
            return Json(true);
        return Json("Toto je povinné pole");
    }
}