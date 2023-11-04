using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace LogMeIn.Models.Models;

public class ExhibitedCat : Cat
{
    [Required(ErrorMessage = "Tento atribut je povinný")]
    public override string Name
    {
        get => base.Name ?? "";
        set => base.Name = value;
    }

    [Required(ErrorMessage = "Tento atribut je povinný")]
    public override string Ems
    {
        get => base.Ems ?? "";
        set => base.Ems = value;
    }

    public override string PedigreeNumber
    {
        get => base.PedigreeNumber ?? "";
        set => base.PedigreeNumber = value;
    }

    [Required(ErrorMessage = "Tento atribut je povinný")]
    public override string Colour
    {
        get => base.Colour ?? "";
        set => base.Colour = value;
    }

    [Required(ErrorMessage = "Tento atribut je povinný")]
    public override string Breed
    {
        get => base.Breed ?? "";
        set => base.Breed = value;
    }

    [Required(ErrorMessage = "Tento atribut je povinný")]
    public DateTime BirthDate { get; set; }

    [Required(ErrorMessage = "Tento atribut je povinný")]
    public bool Neutered { get; set; }

    public string BreederId { get; set; } = null!;

    [ForeignKey(nameof(BreederId))]
    [ValidateNever]
    public virtual Breeder Breeder { get; set; } = null!;

    public int? FatherId { get; set; }

    [ForeignKey(nameof(FatherId))]
    [ValidateNever]
    public virtual Cat? Father { get; set; }

    public int? MotherId { get; set; }

    [ForeignKey(nameof(MotherId))]
    [ValidateNever]
    public virtual Cat? Mother { get; set; }

    [Required(ErrorMessage = "Tento atribut je povinný")]
    public bool IsSameAsExhibitor { get; set; } = true;

    [Required(ErrorMessage = "Tento atribut je povinný")]
    public bool IsHomeCat { get; set; } = false;
    
    public int? Group { get; set; } // TODO change me ASAPA - i am set to -1
}