using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace LogMeIn.Models.Models;

public class ApplicationUser : IdentityUser, IBreeder, IBaseModel<string>
{
    public ApplicationUser()
    {
    }


    public ApplicationUser(string userName, string name, string surname, string telephoneNumber,
        string email,
        string country, string city, string address, string zipCode, string memberNumber, DateTime dateOfBirth,
        string houseNumber, string organization, bool emailCOnfirmed) : base(userName)
    {
        FirstName = name ?? throw new ArgumentNullException(nameof(name));
        LastName = surname ?? throw new ArgumentNullException(nameof(surname));
        Country = country ?? throw new ArgumentNullException(nameof(country));
        City = city ?? throw new ArgumentNullException(nameof(city));
        Street = address ?? throw new ArgumentNullException(nameof(address));
        ZipCode = zipCode;
        MemberNumber = memberNumber;
        DateOfBirth = dateOfBirth;
        HouseNumber = houseNumber;
        base.Email = email ?? throw new ArgumentNullException(nameof(email));
        //todo  [RegularExpression(@"(\+\d{1,4}\s?)?\d{3}[-\s]?\d{3}[-\s]?\d{3}", ErrorMessage = "Špatný formát tel čísla")]
        base.PhoneNumber = telephoneNumber ?? throw new ArgumentNullException(nameof(telephoneNumber));
        Organization = organization;
        EmailConfirmed = emailCOnfirmed;
    }

    [Required(ErrorMessage = "Tento atribut je povinný")]
    [Display(Name = "Město")]
    public string City { get; set; } = null!;

    [Required(ErrorMessage = "Tento atribut je povinný")]
    [Display(Name = "Ulice")]
    public string Street { get; set; } = null!;

    [Required(ErrorMessage = "Tento atribut je povinný")]
    [Display(Name = "Číslo popisné")]
    public string HouseNumber { get; set; }

    [Required(ErrorMessage = "Tento atribut je povinný")]
    [RegularExpression(@"^\d{3}\s?\d{2}$", ErrorMessage = "Špatný formát PSČ")]
    [Display(Name = "PSČ")]
    public string ZipCode { get; set; } = null!;

    [MinLength(5)]
    [Required(ErrorMessage = "Tento atribut je povinný")]
    [Display(Name = "Organizace")]
    public string? Organization { get; set; }

    [Required(ErrorMessage = "Tento atribut je povinný")]
    [RegularExpression(@"^\d{6}$", ErrorMessage = "Špatný formát průkazu")]
    [Display(Name = "Členské číslo")]
    public string MemberNumber { get; set; }


    [Required(ErrorMessage = "Tento atribut je povinný")]
    [Display(Name = "Datum narození")]
    [DataType(DataType.DateTime)]
    public DateTime DateOfBirth { get; set; }

    public virtual List<PersonRegistration> PersonRegistrations { get; set; } = new();


    [Required(ErrorMessage = "Tento atribut je povinný")]
    [Display(Name = "Křestní jméno")]
    public string FirstName { get; set; } = null!;

    [Required(ErrorMessage = "Tento atribut je povinný")]
    [Display(Name = "Příjmení")]
    public string LastName { get; set; } = null!;

    [Required(ErrorMessage = "Tento atribut je povinný")]
    [Display(Name = "Země")]
    public string Country { get; set; } = null!;

    public void CopyValuesTo(ApplicationUser other)
    {
        other.FirstName = FirstName;
        other.LastName = LastName;
        other.Country = Country;
        other.City = City;
        other.Street = Street;
        // other.Email = Email;
        other.Organization = Organization;
        other.MemberNumber = MemberNumber;
        other.ZipCode = ZipCode;
        other.DateOfBirth = DateOfBirth.AddHours(12).ToUniversalTime();
        other.HouseNumber = HouseNumber;
        other.Country = Country;
        // other.NormalizedEmail = NormalizedEmail;
        other.PhoneNumber = PhoneNumber;
    }
}