using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace LogMeIn.Models.Models;

public class Organization : BaseModel
{
    public Organization()
    {
    }

    public Organization(int id, string ico, string name, string email, string telNumber, string website, int placeId)
    {
        Id = id;
        Ico = ico ?? throw new ArgumentNullException(nameof(ico));
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Email = email ?? throw new ArgumentNullException(nameof(email));
        TelNumber = telNumber ?? throw new ArgumentNullException(nameof(telNumber));
        Website = website ?? throw new ArgumentNullException(nameof(website));
        PlaceId = placeId;
    }

    [Required(ErrorMessage = "Tento atribut je povinný")]
    public string Name { get; set; } = null!;

    [Required(ErrorMessage = "Tento atribut je povinný")]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "Tento atribut je povinný")]
    public string Ico { get; set; } = null!;

    [Required(ErrorMessage = "Tento atribut je povinný")]
    public string TelNumber { get; set; } = null!;

    [Required(ErrorMessage = "Tento atribut je povinný")]
    public string Website { get; set; } = null!;

    public virtual IEnumerable<Exhibition> Exhibitions { get; set; }

    [Required(ErrorMessage = "Tento atribut je povinný")]
    public int PlaceId { get; set; }

    [ForeignKey(nameof(PlaceId))]
    [ValidateNever]
    public virtual Location Place { get; set; } = null!;
}