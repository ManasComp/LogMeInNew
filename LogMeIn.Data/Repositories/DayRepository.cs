using LogMeIn.Data.Data;
using LogMeIn.Data.Repositories.IRepositories;
using LogMeIn.Models.Models;

namespace LogMeIn.Data.Repositories;

public class DayRepository : Repository<Day<CatRegistration>, int>, IDayRepository
{
    public DayRepository(ApplicationDbContext db) : base(db)
    {
    }
}