using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LogMeIn.Models.ViewModels;

public class EnumVm
{
    public IEnumerable<SelectListItem> Groups { get; set; } = new List<SelectListItem>();
    public string Name { get; set; }

    [Required(ErrorMessage = "Tento atribut je povinný")]
    public int SelectedId { get; set; }
}