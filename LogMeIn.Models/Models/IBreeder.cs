using System.ComponentModel.DataAnnotations;

namespace LogMeIn.Models.Models;

public interface IBreeder
{
    [Key] public string Id { get; set; }

    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Country { get; set; }
}