// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

#nullable disable

using System.ComponentModel.DataAnnotations;
using LogMeIn.Data.Repositories.IRepositories;
using LogMeIn.Models.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LogMeIn.Areas.Identity.Pages.Account.Manage;

public class IndexModel : PageModel
{
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly IUnitOfWork _unitOfWork;
    private readonly UserManager<ApplicationUser> _userManager;

    public IndexModel(
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        IUnitOfWork unitOfWork)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _unitOfWork = unitOfWork;
    }

    /// <summary>
    ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
    ///     directly from your code. This API may change or be removed in future releases.
    /// </summary>
    [Display(Name = "Přihlašovací jméno")]
    public string Username { get; set; }

    /// <summary>
    ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
    ///     directly from your code. This API may change or be removed in future releases.
    /// </summary>
    [TempData]
    public string StatusMessage { get; set; }

    /// <summary>
    ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
    ///     directly from your code. This API may change or be removed in future releases.
    /// </summary>
    [BindProperty]
    public InputModel Input { get; set; }

    private async Task LoadAsync(ApplicationUser user)
    {
        var userName = await _userManager.GetUserNameAsync(user);
        var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
        var firstName = user.FirstName;
        var lastName = user.LastName;
        var country = user.Country;
        var city = user.City;
        var street = user.Street;
        var zipCode = user.ZipCode;
        var memberNumber = user.MemberNumber;
        var dateOfBirth = user.DateOfBirth;
        var houseNumber = user.HouseNumber;
        var organization = user.Organization;

        Username = userName;

        Input = new InputModel
        {
            PhoneNumber = phoneNumber,
            FirstName = firstName,
            LastName = lastName,
            Country = country,
            City = city,
            Street = street,
            ZipCode = zipCode,
            MemberNumber = memberNumber,
            DateOfBirth = dateOfBirth,
            HouseNumber = houseNumber,
            Organization = organization
        };
    }

    public async Task<IActionResult> OnGetAsync()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null) return NotFound($"Nelze načíst uživatele s ID '{_userManager.GetUserId(User)}'.");

        await LoadAsync(user);
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null) return NotFound($"Nelze načíst uživatele s ID '{_userManager.GetUserId(User)}'.");

        if (!ModelState.IsValid)
        {
            await LoadAsync(user);
            return Page();
        }

        var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
        if (Input.PhoneNumber != phoneNumber)
        {
            var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
            if (!setPhoneResult.Succeeded)
            {
                StatusMessage = "Neočekávaná chyba při nastavování telefonního čísla.";
                return RedirectToPage();
            }
        }

        var x2 = _unitOfWork.OrderRepository.Get(x => x.PersonRegistration.Exhibiter.Id == user.Id);
        if (_unitOfWork.OrderRepository.Get(x => x.PersonRegistration.Exhibiter.Id == user.Id,
                x => x.PersonRegistration, x => x.Exhibiter) != null)
        {
            StatusMessage = "Nelze změnit údaje, protože už máte objednávku";
            return RedirectToPage();
        }

        if (Input.FirstName != user.FirstName) user.FirstName = Input.FirstName;
        if (Input.LastName != user.LastName) user.LastName = Input.LastName;
        if (Input.Country != user.Country) user.Country = Input.Country;
        if (Input.City != user.City) user.City = Input.City;
        if (Input.Street != user.Street) user.Street = Input.Street;
        if (Input.ZipCode != user.ZipCode) user.ZipCode = Input.ZipCode;
        if (Input.MemberNumber != user.MemberNumber) user.MemberNumber = Input.MemberNumber;
        if (Input.DateOfBirth != user.DateOfBirth) user.DateOfBirth = Input.DateOfBirth;
        if (Input.HouseNumber != user.HouseNumber) user.HouseNumber = Input.HouseNumber;
        if (Input.Organization != user.Organization) user.Organization = Input.Organization;
        await _userManager.UpdateAsync(user);

        await _signInManager.RefreshSignInAsync(user);
        StatusMessage = "Váš profil byl úspěšně aktualizován";
        return RedirectToPage();
    }

    /// <summary>
    ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
    ///     directly from your code. This API may change or be removed in future releases.
    /// </summary>
    public class InputModel
    {
        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [Phone]
        [Display(Name = "Telefonní číslo")]
        public string PhoneNumber { get; set; }

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
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Tento atribut je povinný")]
        [Display(Name = "Křestní jméno")]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = "Tento atribut je povinný")]
        [Display(Name = "Příjmení")]
        public string LastName { get; set; } = null!;

        [Required(ErrorMessage = "Tento atribut je povinný")]
        [Display(Name = "Země")]
        public string Country { get; set; } = null!;
    }
}