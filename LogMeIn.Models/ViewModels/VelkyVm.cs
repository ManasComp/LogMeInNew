namespace LogMeIn.Models.ViewModels;

public class VelkyVm
{
    public VelkyVm(string name, double price, int id)
    {
        Name = name;
        Price = price;
        Id = id;
    }

    public string Name { get; set; }
    public int Id { get; set; }
    public double Price { get; set; }
}