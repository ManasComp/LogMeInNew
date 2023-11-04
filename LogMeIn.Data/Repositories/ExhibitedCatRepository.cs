using LogMeIn.Data.Data;
using LogMeIn.Data.Repositories.IRepositories;
using LogMeIn.Models.Models;

namespace LogMeIn.Data.Repositories;

public class ExhibitedCatRepository : Repository<ExhibitedCat, int>, IIExhibitedCatRepository
{
    public ExhibitedCatRepository(ApplicationDbContext db) : base(db)
    {
    }
}