using LogMeIn.Data.Data;
using LogMeIn.Data.Repositories.IRepositories;
using LogMeIn.Models.Models;

namespace LogMeIn.Data.Repositories;

public class OrderRepository : Repository<Order, int>, IOrderRepository

{
    public OrderRepository(ApplicationDbContext db) : base(db)
    {
    }
}