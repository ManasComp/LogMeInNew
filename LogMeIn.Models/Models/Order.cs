using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace LogMeIn.Models.Models;

public class Order : BaseModel
{
    [Required] public DateTime Submitted { get; set; }

    [Required] public int PersonRegistrationId { get; set; }

    [ForeignKey(nameof(PersonRegistrationId))]
    [ValidateNever]
    public virtual PersonRegistration PersonRegistration { get; set; } = null!;

    [Required] public double Price { get; set; }

    [Required] public OrderStatus OrderStatus { get; set; } = OrderStatus.Submitted;
}