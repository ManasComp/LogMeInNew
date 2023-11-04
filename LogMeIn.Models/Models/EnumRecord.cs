using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace LogMeIn.Models.Models;

public class EnumRecord : BaseModel
{
    [Required(ErrorMessage = "Tento atribut je povinný")]
    public int FeeId { get; set; }

    [ValidateNever]
    [ForeignKey(nameof(FeeId))]
    public virtual EnumFee Fee { get; set; } = null!;

    [Required(ErrorMessage = "Tento atribut je povinný")]
    public string Name { get; set; } = null!;

    [Required(ErrorMessage = "Tento atribut je povinný")]
    public bool Default { get; set; }

    [Required(ErrorMessage = "Tento atribut je povinný")]
    public double PriceKc { get; set; } //kč eur

    [Required(ErrorMessage = "Tento atribut je povinný")]
    public double PriceEur { get; set; } //kč euro
}