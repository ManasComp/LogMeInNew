using System.Linq.Expressions;
using LogMeIn.Models.Models;

namespace Tests;

public class Storage : BaseModel
{
    public Storage(Record attribute, status stat, LambdaExpression? filter = null)
    {
        this.attribute = attribute;
        Stat = stat;
        Filter = filter;
    }

    public status Stat { get; set; }

    public Record attribute { get; set; }

    public LambdaExpression? Filter { get; set; }
}

public enum status
{
    valid,
    invalid,
    error
}