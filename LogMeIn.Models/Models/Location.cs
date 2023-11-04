using System.ComponentModel.DataAnnotations;

namespace LogMeIn.Models.Models;

public class Location : BaseModel
{
    public Location()
    {
    }

    public Location(int id, string address, string north, string south)
    {
        Id = id;
        Address = address ?? throw new ArgumentNullException(nameof(address));
        North = north ?? throw new ArgumentNullException(nameof(north));
        South = south ?? throw new ArgumentNullException(nameof(south));
    }

    [Required(ErrorMessage = "Tento atribut je povinný")] public string Address { get; set; } = null!;
    [Required(ErrorMessage = "Tento atribut je povinný")] public string North { get; set; } = null!;
    [Required(ErrorMessage = "Tento atribut je povinný")] public string South { get; set; } = null!;
}