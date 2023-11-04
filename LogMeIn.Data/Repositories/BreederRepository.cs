using LogMeIn.Data.Data;
using LogMeIn.Data.Repositories.IRepositories;
using LogMeIn.Models.Models;

namespace LogMeIn.Data.Repositories;

public class BreederRepository : Repository<Breeder, string>, IBreederRepository
{
    public BreederRepository(ApplicationDbContext db) : base(db)
    {
    }
}