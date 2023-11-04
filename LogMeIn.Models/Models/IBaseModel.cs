namespace LogMeIn.Models.Models;

public interface IBaseModel<T> where T : notnull, IComparable<T>, IComparable
{
    T Id { get; set; }
}