using LogMeIn.Data.Data;
using LogMeIn.Data.Repositories.IRepositories;
using LogMeIn.Models.Models;

namespace LogMeIn.Data.Repositories;

public class FeeItemRepository : Repository<FeeDetail, int>, IFeeItemsRepository
{
    public FeeItemRepository(ApplicationDbContext db) : base(db)
    {
    }
}