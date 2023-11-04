using System.ComponentModel.DataAnnotations;

namespace LogMeIn.Models.Models;

public class Breeder : DefaultFake, IBreeder, IBaseModel<string>
{
    [Key] public string Id { get; set; } = Guid.NewGuid().ToString();

    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Country { get; set; }
}