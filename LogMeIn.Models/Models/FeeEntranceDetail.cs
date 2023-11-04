using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace LogMeIn.Models.Models;

public class FeeEntranceDetail : BaseModel
{
    [Required(ErrorMessage = "Tento atribut je povinný")]
    public int ExhibitionId { get; set; }

    [ForeignKey(nameof(ExhibitionId))]
    [ValidateNever]
    public Exhibition Exhibition { get; set; } = null!;

    [Required(ErrorMessage = "Tento atribut je povinný")]
    public int MinCount { get; set; }

    [Required(ErrorMessage = "Tento atribut je povinný")]
    public int MaxCount { get; set; }

    [Required(ErrorMessage = "Tento atribut je povinný")]
    public double PriceKc { get; set; } //kč eur

    [Required(ErrorMessage = "Tento atribut je povinný")]
    public double PriceEur { get; set; } //kč euro

    public virtual IEnumerable<ManyToManyMapper<FeeEntranceDetail>> ExhibitedGroup { get; set; } =
        new List<ManyToManyMapper<FeeEntranceDetail>>();

    [Required(ErrorMessage = "Tento atribut je povinný")]
    public int MinNumberOfCats { get; set; }

    [Required(ErrorMessage = "Tento atribut je povinný")]
    public int MaxNumberOfCats { get; set; }
}