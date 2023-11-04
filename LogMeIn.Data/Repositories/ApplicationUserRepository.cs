using LogMeIn.Data.Data;
using LogMeIn.Data.Repositories.IRepositories;
using LogMeIn.Models.Models;

namespace LogMeIn.Data.Repositories;

public class ApplicationUserRepository : Repository<ApplicationUser, string>, IApplicationUserRepository
{
    public ApplicationUserRepository(ApplicationDbContext db) : base(db)
    {
    }
}