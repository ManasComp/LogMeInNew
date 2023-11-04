using LogMeIn.Models.Models;

namespace LogMeIn.Data.Repositories.IRepositories;

public interface IUnitOfWork
{
    IExhibitionRepository Exhibition { get; }

    IApplicationUserRepository ApplicationUserRepository { get; }

    ICatRegistrationRepository CatRegistration { get; }

    ICatRepository Cat { get; }


    IIExhibitedCatRepository ExhibitedCatRepository { get; set; }

    IBreederRepository BreederRepository { get; set; }

    public FeeItemRepository FeeItemRepository { get; set; }

    public PersonRegistrationRepository PersonRegistration { get; set; }

    public DayRepository Day { get; set; }

    public IStoreRepository<CatRegistration, Fee, bool> CatFees { get; set; }
    public StoreRepository<Day<CatRegistration>, Fee, bool> DayFees { get; set; }
    public StoreRepository<PersonRegistration, Fee, bool> PersonFees { get; set; }

    public StoreRepository<PersonRegistration, EnumFee, int> EnumFees { get; set; }

    public PersonFeesRepository FeeRecords { get; set; }

    public ManyToManyRepository<CatRegistration> ManyToManyCat { get; set; }

    public IOrderRepository OrderRepository { get; set; }


    void Save();
}