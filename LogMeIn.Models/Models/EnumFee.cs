using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace LogMeIn.Models.Models;

public class EnumFee : BaseModel
{
    [Required(ErrorMessage = "Tento atribut je povinný")]
    public string Name { get; set; } = null!;

    [Required(ErrorMessage = "Tento atribut je povinný")]
    public Types Type { get; set; }

    [Required(ErrorMessage = "Tento atribut je povinný")]
    public int ExhibitionId { get; set; }

    [ForeignKey(nameof(ExhibitionId))]
    [ValidateNever]
    public virtual Exhibition WExhibition { get; set; } = null!;

    public virtual ICollection<EnumRecord> FeeRecords { get; set; } = new List<EnumRecord>();
}