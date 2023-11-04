using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LogMeIn.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LogMeIn.Models.Models;

public class PersonRegistration : DefaultFake
{
    [Required(ErrorMessage = "Tento atribut je povinný")]
    public string ExhibiterId { get; set; } = null!;

    [ForeignKey(nameof(ExhibiterId))]
    [ValidateNever]
    public virtual ApplicationUser Exhibiter { get; set; } = null!;


    [Required(ErrorMessage = "Tento atribut je povinný")]
    public int ExhibitionId { get; set; }

    [ForeignKey(nameof(ExhibitionId))]
    [ValidateNever]
    public virtual Exhibition Exhibition { get; set; } = null!;

    public virtual Order? Order { get; set; }

    public virtual List<StoredFees<PersonRegistration, Fee, bool>> CompleteFees { get; set; } = new();
    public virtual List<StoredFees<PersonRegistration, EnumFee, int>> PersonEnumFee { get; set; } = new();

    public virtual ICollection<CatRegistration> CatRegistrations { get; set; } = new List<CatRegistration>();

    public List<CatRegistration> getNotDraftCatRegistrations(ICollection<CatRegistration> catRegistration)
    {
        return catRegistration
            .Where(x => x.isDraft(x.Cat.IsHomeCat))
            .ToList();
    }

    public List<EnumVm> GetEnumVms(List<StoredFees<PersonRegistration, EnumFee, int>> fees)
    {
        return fees.Select(x => new EnumVm
        {
            Groups = x.Fee.FeeRecords.Select(y => new SelectListItem
            {
                Text = y.Name,
                Value = y.Id.ToString()
            }),
            Name = x.Fee.Name,
            SelectedId = x.bought
        }).ToList();
    }
}