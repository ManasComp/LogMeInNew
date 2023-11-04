using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace LogMeIn.Models.Models;

public class CatRegistration : BaseModel
{
    [Required(ErrorMessage = "Tento atribut je povinný")]
    public double Price { get; set; }

    [Required(ErrorMessage = "Tento atribut je povinný")]
    public int CatOrder { get; set; }

    public string? Note { get; set; }

    [Required(ErrorMessage = "Tento atribut je povinný")]
    public int CatId { get; set; }

    [ForeignKey(nameof(CatId))]
    [ValidateNever]
    public virtual ExhibitedCat Cat { get; set; } = null!;

    public int PersonRegistrationId { get; set; }

    [ForeignKey(nameof(PersonRegistrationId))]
    [ValidateNever]
    public virtual PersonRegistration PersonRegistration { get; set; } = null!;

    public virtual IEnumerable<ManyToManyMapper<CatRegistration>> SelectedGroups { get; set; } =
        new List<ManyToManyMapper<CatRegistration>>();

    public virtual ICollection<Day<CatRegistration>> AttendanceOnDays { get; set; } = new List<Day<CatRegistration>>();
    public virtual List<StoredFees<CatRegistration, Fee, bool>> CompleteFees { get; set; } = new();

    public int LastStep { get; set; }

    public bool isDraft(bool isHomeCat)
    {
        if (isHomeCat)
            return LastStep == 2;
        return LastStep == 4;
    }

    public bool canGoTo(int newStep, bool isHomeCat)
    {
        if (isHomeCat)
            return newStep switch
            {
                0 => LastStep is 0 or 1, //vystavovaná
                1 => LastStep is 0 or 2, //otec
                2 => LastStep is 1 or 3, //matka
                3 => LastStep is 2 or 4, //výstava
                4 => LastStep is 3, //summery
                _ => false
            };
        return newStep switch
        {
            0 => LastStep is 0 or 1, //vystavovaná
            1 => LastStep is 1, //výstava
            2 => LastStep is 2, //summery
            _ => false
        };
    }
}