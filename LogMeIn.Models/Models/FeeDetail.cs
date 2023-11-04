using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace LogMeIn.Models.Models;

public class FeeDetail : BaseModel
{
    [Required(ErrorMessage = "Tento atribut je povinný")]
    public int FeeId { get; set; }

    [ForeignKey(nameof(FeeId))]
    [ValidateNever]
    public virtual Fee Fee { get; set; } = null!;

    [Required(ErrorMessage = "Tento atribut je povinný")]
    public int MinCount { get; set; }

    [Required(ErrorMessage = "Tento atribut je povinný")]
    public int MaxCount { get; set; }

    [Required(ErrorMessage = "Tento atribut je povinný")]
    public double PriceKc { get; set; } //kč eur

    [Required(ErrorMessage = "Tento atribut je povinný")]
    public double PriceEur { get; set; } //kč euro
}