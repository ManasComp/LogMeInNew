using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace LogMeIn.Models.Models;

public class Day<T> : BaseModel
{
    public Day(int registrationId, DateTime date)
    {
        RegistrationId = registrationId;
        Date = date;
    }

    [Required(ErrorMessage = "Tento atribut je povinný")]
    public DateTime Date { get; set; }

    [Required(ErrorMessage = "Tento atribut je povinný")]
    public bool Visited { get; set; } = true;

    [Required(ErrorMessage = "Tento atribut je povinný")]
    public int RegistrationId { get; set; }

    [ForeignKey(nameof(RegistrationId))]
    [ValidateNever]
    public virtual T Registration { get; set; }

    public virtual List<StoredFees<Day<T>, Fee, bool>> DayFees { get; set; }
}