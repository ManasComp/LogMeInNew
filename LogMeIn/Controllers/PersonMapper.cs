using AutoMapper;
using LogMeIn.Data.Repositories.IRepositories;
using LogMeIn.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace LogMeIn.Controllers;

public class PersonMapper : GController
{
    public PersonMapper(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }

    public PersonMapper(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    public Tuple<ModelVm, bool> ConvertToDto(int catRegistrationId)
    {
        var reg = UnitOfWork.PersonRegistration.GetAsQuery(x => x.Id == catRegistrationId)
            .Include(x => x.PersonEnumFee)
            .ThenInclude(x => x.Fee)
            .ThenInclude(x => x.FeeRecords)
            .AsNoTracking()
            .Include(x => x.Exhibiter)
            .FirstOrDefault();

        var df = new ModelVm();
        df.EnumVms = reg.GetEnumVms(reg.PersonEnumFee);

        df.FirstName = reg.Exhibiter.FirstName;
        df.LastName = reg.Exhibiter.LastName;
        df.Email = reg.Exhibiter.Email;
        df.PhoneNumber = reg.Exhibiter.PhoneNumber;
        df.Street = reg.Exhibiter.Street;
        df.City = reg.Exhibiter.City;
        df.ZipCode = reg.Exhibiter.ZipCode;
        df.Country = reg.Exhibiter.Country;
        df.Organization = reg.Exhibiter.Organization;
        df.HouseNumber = reg.Exhibiter.HouseNumber;
        df.MemberNumber = reg.Exhibiter.MemberNumber;
        df.DateOfBirth = reg.Exhibiter.DateOfBirth.ToString("dd. MM. yyy");
        df.PersonRegistrationId = reg.Id;

        return new Tuple<ModelVm, bool>(df, !reg.Draft);
    }

    public void save(int catRegistrationId, ModelVm vm)
    {
        var personRegistration = UnitOfWork.PersonRegistration.GetAsQuery(x => x.Id == catRegistrationId)
            .Include(x => x.PersonEnumFee)
            .ThenInclude(x => x.Fee)
            .ThenInclude(x => x.FeeRecords)
            .FirstOrDefault();

        var enumFee = personRegistration.PersonEnumFee;
        for (var i = 0; i < enumFee.Count; i++)
        {
            // todo posiible more ffees - need to nadle with id
            var enumFees = enumFee.ElementAt(i);
            enumFees.bought = vm.EnumVms.ElementAt(i).SelectedId;
            UnitOfWork.EnumFees.Update(enumFees);
        }

        personRegistration.Draft = false;

        UnitOfWork.PersonRegistration.Update(personRegistration);

        UnitOfWork.Save();
    }
}