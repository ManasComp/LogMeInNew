using LogMeIn.Data.Data;
using LogMeIn.Data.Repositories.IRepositories;
using LogMeIn.Models.Models;

namespace LogMeIn.Data.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _db;

    public UnitOfWork(ApplicationDbContext db)
    {
        _db = db;
        Exhibition = new ExhibitionRepository(_db);
        ApplicationUserRepository = new ApplicationUserRepository(_db);
        CatRegistration = new CatRegistrationRepository(_db);
        Cat = new CatRepository(_db);
        ExhibitedCatRepository = new ExhibitedCatRepository(_db);
        BreederRepository = new BreederRepository(_db);
        FeeItemRepository = new FeeItemRepository(_db);
        PersonRegistration = new PersonRegistrationRepository(_db);
        Day = new DayRepository(_db);
        CatFees = new StoreRepository<CatRegistration, Fee, bool>(_db);
        PersonFees = new StoreRepository<PersonRegistration, Fee, bool>(_db);
        DayFees = new StoreRepository<Day<CatRegistration>, Fee, bool>(_db);
        EnumFees = new StoreRepository<PersonRegistration, EnumFee, int>(_db);
        FeeRecords = new PersonFeesRepository(_db);
        ManyToManyCat = new ManyToManyRepository<CatRegistration>(_db);
        OrderRepository = new OrderRepository(_db);
    }


    public PersonFeesRepository FeeRecords { get; set; }

    public void Save()
    {
        _db.SaveChanges();
    }

    public IExhibitionRepository Exhibition { get; }

    public IOrderRepository OrderRepository { get; set; }

    public IApplicationUserRepository ApplicationUserRepository { get; set; }
    public ICatRegistrationRepository CatRegistration { get; }

    public ICatRepository Cat { get; set; }

    public IIExhibitedCatRepository ExhibitedCatRepository { get; set; }

    public IBreederRepository BreederRepository { get; set; }

    public FeeItemRepository FeeItemRepository { get; set; }

    public PersonRegistrationRepository PersonRegistration { get; set; }

    public DayRepository Day { get; set; }

    public IStoreRepository<CatRegistration, Fee, bool> CatFees { get; set; }
    public StoreRepository<Day<CatRegistration>, Fee, bool> DayFees { get; set; }
    public StoreRepository<PersonRegistration, Fee, bool> PersonFees { get; set; }

    public StoreRepository<PersonRegistration, EnumFee, int> EnumFees { get; set; }

    public ManyToManyRepository<CatRegistration> ManyToManyCat { get; set; }
}