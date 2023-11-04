using System.ComponentModel.DataAnnotations;

namespace LogMeIn.Models.Models;

public class Cat : BaseModel
{
    [Required(ErrorMessage = "Tento atribut je povinný")]
    public Gender Sex { get; set; } = Gender.Female;

    public virtual string? TitleBeforeName { get; set; }
    public virtual string? TitleAfterName { get; set; }
    public virtual string? Name { get; set; }
    public virtual string? Ems { get; set; }
    public virtual string? PedigreeNumber { get; set; }

    public virtual string? Colour { get; set; }
    public virtual string? Breed { get; set; }

    public virtual CatRegistration CatRegistration { get; set; } = null!;

    public virtual Cat Clone()
    {
        Cat cat = new();
        return cat;
    }
}