using LogMeIn.Models.Models;

namespace Tests;

public class Record : BaseModel
{
    public string EMS_CODE { get; set; }
    public List<string> CodeInCzech { get; set; }
}