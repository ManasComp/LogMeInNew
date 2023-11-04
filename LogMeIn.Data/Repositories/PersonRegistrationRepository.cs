using LogMeIn.Data.Data;
using LogMeIn.Data.Repositories.IRepositories;
using LogMeIn.Models.Models;

namespace LogMeIn.Data.Repositories;

public class PersonRegistrationRepository : Repository<PersonRegistration, int>, IPersonRegistrationRepository
{
    public PersonRegistrationRepository(ApplicationDbContext db) : base(db)
    {
    }
}