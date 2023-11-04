using AutoMapper;
using LogMeIn.Data.Repositories.IRepositories;
using LogMeIn.Models.Models;
using LogMeIn.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace LogMeIn.Controllers;

public class ExhibitedCatMapper : GController
{
    public ExhibitedCatMapper(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }

    public ExhibitedCatMapper(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    public ExhibitedCatVm getAsVm(int catRegistrationId)
    {
        var catRegistration =
            UnitOfWork.CatRegistration.Get(x => x.Id == catRegistrationId, x => x.Cat, y => y.Breeder);
        return new ExhibitedCatVm
        {
            Name = catRegistration.Cat.Name,
            Ems = catRegistration.Cat.Ems,
            BreedingBook = catRegistration.Cat.PedigreeNumber,
            DateOfBirth = catRegistration.Cat.BirthDate,
            Castrated = catRegistration.Cat.Neutered,
            IsSameAsExhibitor = catRegistration.Cat.IsSameAsExhibitor,
            Gender = catRegistration.Cat.Sex,
            BreederId = catRegistration.Cat.BreederId,
            CatId = catRegistration.Cat.Id,
            BreederName = catRegistration.Cat.Breeder.FirstName,
            BreederSurname = catRegistration.Cat.Breeder.LastName,
            BreederCountry = catRegistration.Cat.Breeder.Country,
            CatRegistrationId = catRegistration.Id,
            IsHomeCatSet = catRegistration.Cat.IsHomeCat,
            Colour = catRegistration.Cat.Colour,
            Breed = catRegistration.Cat.Breed,
            TitleBeforeName = catRegistration.Cat.TitleBeforeName,
            TitleAfterName = catRegistration.Cat.TitleAfterName,
            Group = catRegistration.Cat.Group,
            StepId = 0
        };
    }


    public void SaveVm(ExhibitedCatVm vm)
    {
        var breeder = UnitOfWork.BreederRepository.GetById(vm.BreederId);
        if (breeder == null)
            throw new Exception("");
        breeder.FirstName = vm.BreederName;
        breeder.Country = vm.BreederCountry;
        breeder.LastName = vm.BreederSurname;
        UnitOfWork.BreederRepository.Update(breeder);

        var cat = UnitOfWork.ExhibitedCatRepository.GetAsQuery(x => x.Id == vm.CatId)
            .Include(x => x.Mother)
            .Include(x => x.Father)
            .FirstOrDefault();
        if (cat == null)
            throw new Exception("");
        cat.Name = vm.Name;
        cat.Ems = vm.Ems;
        cat.PedigreeNumber = vm.BreedingBook;
        cat.Sex = vm.Gender;
        cat.Neutered = vm.Castrated;
        cat.BirthDate = vm.DateOfBirth;
        cat.IsSameAsExhibitor = vm.IsSameAsExhibitor;
        cat.IsHomeCat = vm.IsHomeCatSet;
        cat.Colour = vm.Colour;
        cat.Breed = vm.Breed;
        cat.TitleAfterName = vm.TitleAfterName;
        cat.TitleBeforeName = vm.TitleBeforeName;
        cat.Group = vm.Group;

        if (cat.IsHomeCat)
        {
            cat.Father = new Cat();
            cat.Mother = new Cat();
        }

        UnitOfWork.Cat.Update(cat.Father);
        UnitOfWork.Cat.Update(cat.Mother);


        UnitOfWork.ExhibitedCatRepository.Update(cat);
        UnitOfWork.Save();
    }
}