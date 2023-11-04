using LogMeIn.Data.Data;
using LogMeIn.Data.Repositories.IRepositories;
using LogMeIn.Models.Models;

namespace LogMeIn.Data.Repositories;

public class CatRepository : Repository<Cat, int>, ICatRepository

{
    public CatRepository(ApplicationDbContext db) : base(db)
    {
    }
}