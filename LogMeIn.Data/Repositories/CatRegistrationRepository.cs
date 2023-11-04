using LogMeIn.Data.Data;
using LogMeIn.Data.Repositories.IRepositories;
using LogMeIn.Models.Models;

namespace LogMeIn.Data.Repositories;

public class CatRegistrationRepository : Repository<CatRegistration, int>, ICatRegistrationRepository
{
    public CatRegistrationRepository(ApplicationDbContext db) : base(db)
    {
    }
}