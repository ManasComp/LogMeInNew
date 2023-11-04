using System.ComponentModel.DataAnnotations;

namespace LogMeIn.Models.Models;

public interface IFakable
{
    [Required(ErrorMessage = "Tento atribut je povinný")] public bool Draft { get; set; }
}