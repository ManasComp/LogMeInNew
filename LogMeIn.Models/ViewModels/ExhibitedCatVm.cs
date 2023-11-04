using System.ComponentModel.DataAnnotations;
using LogMeIn.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace LogMeIn.Models.ViewModels;

public class ExhibitedCatVm : Step
{
    public ExhibitedCatVm(string name = null, string ems = null, string breedingBook = null,
        DateTime dateOfBirth = default, bool castrated = default, string? breederName = null,
        string? breederSurname = null, string? breederCountry = null, bool isSameAsExhibitor = default,
        Gender gender = default)
    {
        Name = name;
        Ems = ems;
        BreedingBook = breedingBook;
        DateOfBirth = dateOfBirth;
        Castrated = castrated;
        BreederName = breederName;
        BreederSurname = breederSurname;
        BreederCountry = breederCountry;
        IsSameAsExhibitor = isSameAsExhibitor;
        Gender = gender;
    }


    public ExhibitedCatVm()
    {
    }


    [Required(ErrorMessage = "Tento atribut je povinný")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Tento atribut je povinný")]
    public string Ems { get; set; }

    [Remote(areaName: "Visitor", controller: nameof(CatRegistration), action: "VerifyBreedingBook",
        AdditionalFields = nameof(DateOfBirth))]
    public string? BreedingBook { get; set; }

    [Required(ErrorMessage = "Tento atribut je povinný")]
    public DateTime DateOfBirth { get; set; }

    [Required(ErrorMessage = "Tento atribut je povinný")]
    public bool Castrated { get; set; }


    [Required(ErrorMessage = "Tento atribut je povinný")]
    public bool IsSameAsExhibitor { get; set; } = true;

    [Required(ErrorMessage = "Tento atribut je povinný")]
    public Gender Gender { get; set; } = Gender.Female;

    [Required(ErrorMessage = "Tento atribut je povinný")]
    public string BreederId { get; set; }

    [Required(ErrorMessage = "Tento atribut je povinný")]
    public int CatId { get; set; }

    [Remote(areaName: "Visitor", controller: nameof(CatRegistration), action: "VerifyBreederName",
        AdditionalFields = nameof(IsSameAsExhibitor))]
    public string? BreederName { get; set; }

    [Remote(areaName: "Visitor", controller: nameof(CatRegistration), action: "VerifyBreederSurname",
        AdditionalFields = nameof(IsSameAsExhibitor))]
    public string? BreederSurname { get; set; }

    [Remote(areaName: "Visitor", controller: nameof(CatRegistration), action: "VerifyBreederCountry",
        AdditionalFields = nameof(IsSameAsExhibitor))]
    public string? BreederCountry { get; set; }

    [Required(ErrorMessage = "Tento atribut je povinný")]
    public bool IsHomeCatSet { get; set; } = false;

    [Required(ErrorMessage = "Tento atribut je povinný")]
    public string Colour { get; set; }

    [Required(ErrorMessage = "Tento atribut je povinný")]
    public string Breed { get; set; }

    public string? TitleBeforeName { get; set; }
    public string? TitleAfterName { get; set; }

    [Remote(areaName: "Visitor", controller: nameof(CatRegistration), action: "VerifyGroup",
        AdditionalFields = nameof(Ems))]
    [Range(1, 12, ErrorMessage = "Hodnota musí být mezi 1 a 12")]
    public int? Group { get; set; }
}