using AutoMapper;
using LogMeIn.Data.Repositories.IRepositories;
using LogMeIn.Models;
using LogMeIn.Models.Models;
using LogMeIn.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace LogMeIn.Controllers;

public class Helper1 : GController
{
    public Helper1(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }

    public Helper1(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    public AdminVm Cat(int catRegistrationId)
    {
        var mapper = new ExhibitionMapper(UnitOfWork);
        var mapper2 = new ParentMapper(UnitOfWork);
        var mapper3 = new ExhibitedCatMapper(UnitOfWork);
        var x = new AdminVm();

        x.Exhibition = mapper.ConvertToDto(catRegistrationId);
        x.Exhibition.Disabled = true;

        x.Father = mapper2.ConvertToDto(catRegistrationId, Gender.Male);
        x.Father.Disabled = true;

        x.Mother = mapper2.ConvertToDto(catRegistrationId, Gender.Female);
        x.Mother.Disabled = true;

        x.ExhibitedCatVm = mapper3.getAsVm(catRegistrationId);
        x.ExhibitedCatVm.Disabled = true;

        x.RegId = catRegistrationId;

        if (x.ExhibitedCatVm.IsSameAsExhibitor)
        {
            var y = getBreeder(catRegistrationId);
            x.ExhibitedCatVm.BreederName = y.FirstName;
            x.ExhibitedCatVm.BreederSurname = y.LastName;
            x.ExhibitedCatVm.BreederCountry = y.Country;
        }

        x.PersonegID = UnitOfWork.CatRegistration.GetAsQuery(x => x.Id == catRegistrationId)
            .Include(x => x.PersonRegistration)
            .FirstOrDefault().PersonRegistration.Id;
        return x;
    }

    public IBreeder getBreeder(int catRegistrationId)
    {
        return UnitOfWork.CatRegistration.GetAsQuery(x => x.Id == catRegistrationId)
            .Include(x => x.PersonRegistration)
            .ThenInclude(x => x.Exhibiter)
            .FirstOrDefault().PersonRegistration.Exhibiter;
    }
}