using LogMeIn.Models.Models;

namespace LogMeIn.Data.Repositories.IRepositories;

public interface IStoreRepository<T, TK, TU> : IRepository<StoredFees<T, TK, TU>, int>
{
}