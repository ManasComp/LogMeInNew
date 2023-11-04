using LogMeIn.Models.Models;

namespace LogMeIn.Data.Repositories.IRepositories;

public interface IManyToManyepository<T> : IRepository<ManyToManyMapper<T>, int>
{
}