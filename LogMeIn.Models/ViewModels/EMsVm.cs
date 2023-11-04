namespace LogMeIn.Models.ViewModels;

public class EMsVm
{
    public string Name { get; set; }


    public string Ems { get; set; }


    public string? BreedingBook { get; set; }


    public DateTime DateOfBirth { get; set; }


    public bool Castrated { get; set; }


    public bool IsSameAsExhibitor { get; set; } = true;


    public Gender Gender { get; set; }


    public string BreederId { get; set; }


    public int CatId { get; set; }

    public string? BreederName { get; set; }

    public string? BreederSurname { get; set; }

    public string? BreederCountry { get; set; }

    public string Colour { get; set; }


    public string Breed { get; set; }
    public bool IsHomeCat { get; set; } = false;

    public string? TitleBeforeName { get; set; }
    public string? TitleAfterName { get; set; }
}