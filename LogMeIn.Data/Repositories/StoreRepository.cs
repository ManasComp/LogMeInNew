using LogMeIn.Data.Data;
using LogMeIn.Data.Repositories.IRepositories;
using LogMeIn.Models.Models;

namespace LogMeIn.Data.Repositories;

public class StoreRepository<T, TK, TU> : Repository<StoredFees<T, TK, TU>, int>, IStoreRepository<T, TK, TU>
{
    public StoreRepository(ApplicationDbContext db) : base(db)
    {
    }
}