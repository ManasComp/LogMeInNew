using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace LogMeIn.Models.Models;

public class Exhibition : BaseModel

{
    [Required(ErrorMessage = "Tento atribut je povinný")]
    public string Name { get; set; } = null!;

    [Required(ErrorMessage = "Tento atribut je povinný")]
    public string Description { get; set; } = null!;

    [Required(ErrorMessage = "Tento atribut je povinný")]
    public string Url { get; set; } = null!;

    [DisplayName("Start Date")]
    [Required(ErrorMessage = "Tento atribut je povinný")]
    public DateTime StartDate { get; set; }

    [DisplayName("End Date")]
    [Required(ErrorMessage = "Tento atribut je povinný")]
    public DateTime EndDate { get; set; }

    [DisplayName("End of Registration")]
    [Required(ErrorMessage = "Tento atribut je povinný")]
    public DateTime RegistrationEnd { get; set; }

    [Required(ErrorMessage = "Tento atribut je povinný")]
    public int LocationId { get; set; }

    [ForeignKey(nameof(LocationId))]
    [ValidateNever]
    public virtual Location Location { get; set; } = null!;

    [Required(ErrorMessage = "Tento atribut je povinný")]
    public int OrganizationId { get; set; }

    [ForeignKey("OrganizationId")]
    [ValidateNever]
    public virtual Organization Organization { get; set; } = null!;

    public virtual ICollection<Fee> Fees { get; } = new List<Fee>();
    public virtual ICollection<EnumFee> EnumFees { get; } = new List<EnumFee>();

    public virtual ICollection<FeeEntranceDetail> Price { get; set; } = new List<FeeEntranceDetail>();

    public virtual ICollection<PersonRegistration> DaysPersonRegistrations { get; set; } =
        new List<PersonRegistration>();
}