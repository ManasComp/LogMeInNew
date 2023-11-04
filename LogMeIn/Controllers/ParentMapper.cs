using System.Linq.Expressions;
using AutoMapper;
using LogMeIn.Data.Repositories.IRepositories;
using LogMeIn.Models;
using LogMeIn.Models.Models;
using LogMeIn.Models.ViewModels;

namespace LogMeIn.Controllers;

public class ParentMapper : GController
{
    public ParentMapper(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }

    public ParentMapper(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    public CatVm ConvertToDto(int catRegistrationId, Gender gender)
    {
        var stepVm = new CatVm();
        var catRegistration =
            UnitOfWork.CatRegistration.Get(x => x.Id == catRegistrationId, x => x.PersonRegistration);
        if (catRegistration == null)
            throw new Exception("");

        Expression<Func<ExhibitedCat, Cat>> expr;
        int steId;
        if (gender == Gender.Male)
        {
            steId = 1;
            expr = x => x.Father;
        }
        else
        {
            steId = 2;
            expr = x => x.Mother;
        }

        var cat = UnitOfWork.ExhibitedCatRepository.Get(x => x.Id == catRegistration.CatId, expr);
        if (cat == null)
            throw new Exception("");
        var parent = expr.Compile()(cat);
        if (parent == null)
            throw new Exception("");

        stepVm.CatId = parent.Id;
        stepVm.Name = parent.Name;
        stepVm.Ems = parent.Ems;
        stepVm.BreedingBook = parent.PedigreeNumber;
        stepVm.StepId = steId;
        stepVm.Gender = parent.Sex;
        stepVm.CatRegistrationId = catRegistration.Id;
        stepVm.isHomeCat = cat.IsHomeCat;
        stepVm.Colour = parent.Colour;
        stepVm.Breed = parent.Breed;
        stepVm.TitleAfterName = parent.TitleAfterName;
        stepVm.TitleBeforeName = parent.TitleBeforeName;

        return stepVm;
    }

    public void SaveModel(CatVm vm)
    {
        var cat = UnitOfWork.Cat.Get(x => x.Id == vm.CatId);
        cat.Name = vm.Name;
        cat.Ems = vm.Ems;
        cat.PedigreeNumber = vm.BreedingBook;
        cat.Sex = vm.Gender;
        cat.Colour = vm.Colour;
        cat.Breed = vm.Breed;
        cat.TitleAfterName = vm.TitleAfterName;
        cat.TitleBeforeName = vm.TitleBeforeName;

        UnitOfWork.Cat.Update(cat);
        UnitOfWork.Save();
    }
}