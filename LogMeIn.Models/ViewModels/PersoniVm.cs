namespace LogMeIn.Models.ViewModels;

public class PersoniVm
{
    public List<EnumVm> EnumVms { get; set; }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string DateOfBirth { get; set; }
    public string Email { get; set; }
    public string Street { get; set; }
    public string Organization { get; set; }
    public string MemberNumber { get; set; }
    public string HouseNumber { get; set; }

    public string City { get; set; }

    public string ZipCode { get; set; }

    public string Country { get; set; }

    public bool Disabled { get; set; } = false;
}