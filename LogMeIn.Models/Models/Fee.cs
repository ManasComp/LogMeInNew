using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace LogMeIn.Models.Models;

public class Fee : BaseModel
{
    [Required(ErrorMessage = "Tento atribut je povinný")]
    public string Name { get; set; } = null!;

    [Required(ErrorMessage = "Tento atribut je povinný")]
    public Types Type { get; set; }

    [Required(ErrorMessage = "Tento atribut je povinný")]
    public bool DefaultBought { get; set; } = true;

    [Required(ErrorMessage = "Tento atribut je povinný")]
    public int ExhibitionId { get; set; }

    public string? JavascriptId { get; set; }

    [ForeignKey(nameof(ExhibitionId))]
    [ValidateNever]
    public virtual Exhibition Exhibition { get; set; } = null!;

    public virtual ICollection<FeeDetail> FeeDetails { get; set; } = new List<FeeDetail>();

    public int? Order { get; set; }
}