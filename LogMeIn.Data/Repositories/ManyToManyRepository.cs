using LogMeIn.Data.Data;
using LogMeIn.Data.Repositories.IRepositories;
using LogMeIn.Models.Models;

namespace LogMeIn.Data.Repositories;

public class ManyToManyRepository<T> : Repository<ManyToManyMapper<T>, int>, IManyToManyepository<T>
{
    public ManyToManyRepository(ApplicationDbContext db) : base(db)
    {
    }
}