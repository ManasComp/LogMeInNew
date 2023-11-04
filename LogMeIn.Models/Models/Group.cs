namespace LogMeIn.Models.Models;

public class Group<T> : BaseModel
{
    public Func<T, bool> Filter { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string GroupId { get; set; }
}