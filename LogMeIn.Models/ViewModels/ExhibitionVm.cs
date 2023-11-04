using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LogMeIn.Models.ViewModels;

public class ExhibitionVm : Step
{
    [ValidateNever] public List<string> Days { get; set; } = new();

    [ValidateNever] public List<List<CheckBox>> AttendanceOnDays { get; set; } = new();

    [ValidateNever] public CheckBox[] CatCompleteFees { get; set; } = Array.Empty<CheckBox>();

    // [ValidateNever] public CheckBox[] PersonCompleteFees { get; set; } = Array.Empty<CheckBox>();

    [ValidateNever] public IEnumerable<SelectListItem> Groups { get; set; } = new List<SelectListItem>();


    [Required(ErrorMessage = "Tento atribut je povinný")]
    public string[] SelectedId { get; set; } = Array.Empty<string>();

    public string? Note { get; set; } = null!;
}