using System.ComponentModel.DataAnnotations;

namespace LogMeIn.Models.ViewModels;

public sealed class CatVm : Step
{
    public int CatId { get; set; }
    public Gender Gender { get; set; } = Gender.Female;

    [Required(ErrorMessage = "Tento atribut je povinný")] public string Name { get; set; }

    [Required(ErrorMessage = "Tento atribut je povinný")] public string Ems { get; set; }

    [Required(ErrorMessage = "Tento atribut je povinný")]public string BreedingBook { get; set; }

    [Required(ErrorMessage = "Tento atribut je povinný")] public string Colour { get; set; }

    [Required(ErrorMessage = "Tento atribut je povinný")] public string Breed { get; set; }

    public string? TitleBeforeName { get; set; }
    public string? TitleAfterName { get; set; }
}