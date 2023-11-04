using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace LogMeIn.Models.Models;

public class StoredFees<T, TK, TU> : BaseModel
{
    public StoredFees(int feeId, int registrationId, TU bought)
    {
        FeeId = feeId;
        RegistrationId = registrationId;
        this.bought = bought;
    }
    
    [Required(ErrorMessage = "Tento atribut je povinný")]
    public int RegistrationId { get; set; }

    [ForeignKey(nameof(RegistrationId))]
    [ValidateNever]
    public virtual T Registration { get; set; }

    [Required(ErrorMessage = "Tento atribut je povinný")]
    public int FeeId { get; set; }

    [ForeignKey(nameof(FeeId))]
    [ValidateNever]
    public virtual TK Fee { get; set; }

    [Required(ErrorMessage = "Tento atribut je povinný")]
    public TU bought { get; set; }
}