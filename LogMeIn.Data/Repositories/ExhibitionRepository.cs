using LogMeIn.Data.Data;
using LogMeIn.Data.Repositories.IRepositories;
using LogMeIn.Models.Models;

namespace LogMeIn.Data.Repositories;

public class ExhibitionRepository : Repository<Exhibition, int>, IExhibitionRepository
{
    public ExhibitionRepository(ApplicationDbContext db) : base(db)
    {
    }
}