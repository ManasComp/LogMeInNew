using System.ComponentModel.DataAnnotations;

namespace LogMeIn.Models.Models;

public class DefaultFake : BaseModel, IFakable
{
    [Required(ErrorMessage = "Tento atribut je povinný")]
    public bool Draft { get; set; } = true;
}