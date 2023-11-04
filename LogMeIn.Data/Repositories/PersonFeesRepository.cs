using LogMeIn.Data.Data;
using LogMeIn.Models.Models;

namespace LogMeIn.Data.Repositories;

public class PersonFeesRepository : Repository<EnumRecord, int>
{
    public PersonFeesRepository(ApplicationDbContext db) : base(db)
    {
    }
}