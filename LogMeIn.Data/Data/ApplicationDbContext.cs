using LogMeIn.Models.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LogMeIn.Data.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }


    public DbSet<ApplicationUser>? ApplicationUsers { get; set; } = null!;
    public DbSet<Breeder>? Breeders { get; set; } = null!;
    public DbSet<Cat>? Cat { get; set; } = null!;
    public DbSet<CatRegistration> CatRegistrations { get; set; } = null!;
    public DbSet<Day<CatRegistration>>? CatDay { get; set; } = null!;
    public DbSet<ExhibitedCat>? ExhibitedCat { get; set; } = null!;
    public DbSet<FeeDetail>? FeeDetails { get; set; } = null!;
    public DbSet<FeeEntranceDetail>? FeeEntranceDetails { get; set; } = null!;
    public DbSet<Exhibition> Exhibitions { get; set; } = null!;
    public DbSet<Organization> Organizations { get; set; } = null!;
    public DbSet<Location> Locations { get; set; } = null!;
    public DbSet<PersonRegistration> PersonRegistrations { get; set; } = null!;
    public DbSet<StoredFees<CatRegistration, Fee, bool>> CatFees { get; set; } = null!;
    public DbSet<StoredFees<PersonRegistration, Fee, bool>> PersonFees { get; set; } = null!;
    public DbSet<ManyToManyMapper<FeeEntranceDetail>> ManyToManyFeeEntrance { get; set; } = null!;
    public DbSet<ManyToManyMapper<CatRegistration>> CatManyToManyMappers { get; set; } = null!;
    public DbSet<Day<CatRegistration>> DayStored { get; set; } = null!;
    public DbSet<Order> Orders { get; set; }
    public DbSet<Fee> Fees { get; set; } = null!;
    public DbSet<EnumFee> EnumFees { get; set; } = null!;
    public DbSet<EnumRecord> EnumRecords { get; set; } = null!;
    public DbSet<StoredFees<PersonRegistration, EnumFee, int>> EnumStoredFees { get; set; } = null!;


    private void SetUpDbScheme(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PersonRegistration>(entity =>
        {
            entity.HasMany(e => e.CompleteFees)
                .WithOne(e => e.Registration)
                .HasForeignKey(e => e.RegistrationId)
                .OnDelete(DeleteBehavior.NoAction);

            entity.HasMany(e => e.CatRegistrations)
                .WithOne(e => e.PersonRegistration)
                .HasForeignKey(e => e.PersonRegistrationId)
                .OnDelete(DeleteBehavior.NoAction);

            entity.HasMany(e => e.PersonEnumFee)
                .WithOne(e => e.Registration)
                .HasForeignKey(e => e.RegistrationId)
                .OnDelete(DeleteBehavior.NoAction);

            entity.HasOne(e => e.Exhibiter)
                .WithMany(x => x.PersonRegistrations)
                .OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<Exhibition>(entity =>
        {
            entity.HasMany(e => e.Price)
                .WithOne(e => e.Exhibition)
                .HasForeignKey(e => e.ExhibitionId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<CatRegistration>(entity =>
        {
            entity.HasMany(e => e.AttendanceOnDays)
                .WithOne(e => e.Registration)
                .HasForeignKey(e => e.RegistrationId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasMany(e => e.CompleteFees)
                .WithOne(e => e.Registration)
                .HasForeignKey(e => e.RegistrationId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasMany(e => e.SelectedGroups)
                .WithOne(e => e.Attribute)
                .HasForeignKey(e => e.AttributeId)
                .OnDelete(DeleteBehavior.Cascade);

            entity
                .HasOne(e => e.Cat)
                .WithOne(x => x.CatRegistration)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Day<CatRegistration>>(entity =>
        {
            entity.HasMany(e => e.DayFees)
                .WithOne(e => e.Registration)
                .HasForeignKey(e => e.RegistrationId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Fee>(entity =>
        {
            entity.HasMany(e => e.FeeDetails)
                .WithOne(e => e.Fee)
                .HasForeignKey(e => e.FeeId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Cat>()
            .Property(x => x.Sex)
            .HasConversion<int>();

        modelBuilder.Entity<EnumFee>(entity =>
        {
            entity.HasMany(e => e.FeeRecords)
                .WithOne(e => e.Fee)
                .HasForeignKey(e => e.FeeId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<FeeEntranceDetail>(entity =>
        {
            entity.HasMany(e => e.ExhibitedGroup)
                .WithOne(e => e.Attribute)
                .HasForeignKey(e => e.AttributeId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Organization>(entity =>
        {
            entity.HasMany(e => e.Exhibitions)
                .WithOne(e => e.Organization)
                .HasForeignKey(e => e.OrganizationId)
                .OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<ExhibitedCat>(entity =>
        {
            entity.HasOne(e => e.Breeder)
                .WithOne()
                // .WithMany()
                // .HasForeignKey(e => e.BreederId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.Breeder)
                .WithOne()
                // .WithMany()
                // .HasForeignKey(e => e.BreederId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.Father)
                .WithOne()
                // .WithMany()
                // .HasForeignKey(e => e.FatherId)
                .OnDelete(DeleteBehavior.NoAction);

            entity.HasOne(e => e.Mother)
                .WithOne()
                // .WithMany()
                // .HasForeignKey(e => e.MotherId)
                .OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<Order>()
            .HasOne(x => x.PersonRegistration)
            .WithOne(x => x.Order)
            .OnDelete(DeleteBehavior.Cascade);

        // foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(entity => entity.GetForeignKeys()))
        //     relationship.DeleteBehavior = DeleteBehavior.Restrict;
    }


    private void SetUpObjects(ModelBuilder modelBuilder)
    {
        var exhibitionId = 0;
        var locationId = 0;
        var organizationId = 0;
        var feeId = 0;
        var feeDetailId = 0;


        var location = new Location(++locationId, "Palackého třída 126", "49.240069", "16.591739");
        var organization = new Organization(++organizationId, "03841979", "Kočky Brno", "KockyBrno@gmail.com",
            "420 604 954 118",
            "https://www.kockybrno.cz/", location.Id);

        var exhibition = new Exhibition
        {
            Id = ++exhibitionId,
            Name = "XV. a XVI. Mezinárodní kočičí výstava",
            Description = "",
            Url = "https://www.schk.cz/files/ko-kyBrno2023.pdf",
            StartDate = new DateTime(2023, 11, 4, 0, 0, 0, 0, DateTimeKind.Utc),
            EndDate = new DateTime(2023, 11, 5, 0, 0, 0, 0, DateTimeKind.Utc),
            RegistrationEnd = new DateTime(2023, 10, 27, 0, 0, 0, 0, DateTimeKind.Utc),
            LocationId = location.Id,
            OrganizationId = organization.Id
        };


        var sturdyFee = new Fee
        {
            Id = ++feeId,
            Name = "Mám sturdy klec větší než 60x60",
            Type = Types.WholeCat,
            ExhibitionId = exhibition.Id,
            JavascriptId = "sturdyFee",
            Order = 1
        };
        var sturdyFeeDeatil = new FeeDetail
        {
            Id = ++feeDetailId,
            MinCount = 1,
            MaxCount = 1,
            PriceKc = 300,
            PriceEur = 4,
            FeeId = sturdyFee.Id
        };

        var ownCage = new Fee
        {
            Id = ++feeId,
            Name = "Mám vlastní klec",
            Type = Types.WholeCat,
            ExhibitionId = exhibition.Id,
            JavascriptId = "ownCage",
            Order = 0
        };
        var ownCageDetail = new FeeDetail
        {
            Id = ++feeDetailId,
            MinCount = 1,
            MaxCount = 1,
            PriceKc = 0,
            PriceEur = 0,
            FeeId = ownCage.Id
        };


        var doubleCage = new Fee
        {
            Id = ++feeId,
            Name = "Dvojitá klec",
            Type = Types.DeyCat,
            ExhibitionId = exhibition.Id,
            JavascriptId = "doubleCage"
        };
        var doubleFeeDeatil = new FeeDetail
        {
            Id = ++feeDetailId,
            MinCount = 1,
            MaxCount = 1,
            PriceKc = 300,
            PriceEur = 4,
            FeeId = doubleCage.Id
        };
        var doubleFeeDeatil1 = new FeeDetail
        {
            Id = ++feeDetailId,
            MinCount = 2,
            MaxCount = 2,
            PriceKc = 600,
            PriceEur = 4,
            FeeId = doubleCage.Id
        };

        var propagationfee = new EnumFee
        {
            Id = ++feeId,
            Name = "Propagace vystavovatele",
            Type = Types.WholePerson,
            ExhibitionId = exhibition.Id
        };
        var enumRecord1 = new EnumRecord
        {
            Id = ++feeId,
            Name = "Propagace na celou A4",
            FeeId = propagationfee.Id,
            Default = false,
            PriceKc = 500
        };
        // var enumRecord2 = new EnumRecord
        // {
        //     Id = ++feeId,
        //     Name = "Propagace na půl A4",
        //     FeeId = propagationfee.Id,
        //     Default = false,
        //     PriceKc = 250
        // };
        var enumRecord3 = new EnumRecord
        {
            Id = ++feeId,
            Name = "Žádná propagace",
            FeeId = propagationfee.Id,
            Default = true,
            PriceKc = 0
        };


        modelBuilder.Entity<Location>().HasData(
            location
        );
        modelBuilder.Entity<Organization>().HasData(
            organization
        );
        modelBuilder.Entity<Exhibition>().HasData(
            exhibition
        );

        modelBuilder.Entity<EnumRecord>().HasData(
            enumRecord1, enumRecord3 //, enumRecord2
        );

        modelBuilder.Entity<EnumFee>().HasData(
            propagationfee
        );

        modelBuilder.Entity<Fee>().HasData(
            sturdyFee, ownCage, doubleCage
        );

        modelBuilder.Entity<FeeDetail>().HasData(
            sturdyFeeDeatil, ownCageDetail, doubleFeeDeatil, doubleFeeDeatil1
        );

        PriceInitialize(modelBuilder, exhibition);
    }

    private void PriceInitialize(ModelBuilder modelBuilder, Exhibition exhibition)
    {
        var feeEntranceDetailId = 0;
        var manyToManyId = 0;

        var tupleList = new List<(FeeEntranceDetail, string)>();

        //************** Tř.1,3,5,7,9 700/1200 Kč a Tř.2,4,6,8,10,11,12 600/1000 Kč **************
        var price1 = new FeeEntranceDetail
        {
            Id = ++feeEntranceDetailId,
            ExhibitionId = exhibition.Id,
            MinCount = 1,
            MaxCount = 1,
            PriceKc = 700,
            PriceEur = 30,
            MaxNumberOfCats = 1,
            MinNumberOfCats = 1
        };
        foreach (var group in new List<string> { "1", "3", "5", "7", "9", "2", "4", "6", "8", "10", "11", "12" })
            tupleList.Add((price1, group));

        var price2 = new FeeEntranceDetail
        {
            Id = ++feeEntranceDetailId,
            ExhibitionId = exhibition.Id,
            MinCount = 2,
            MaxCount = 2,
            PriceKc = 1200,
            PriceEur = 50,
            MaxNumberOfCats = 1,
            MinNumberOfCats = 1
        };
        foreach (var group in new List<string> { "1", "3", "5", "7", "9", "2", "4", "6", "8", "10", "11", "12" })
            tupleList.Add((price2, group));

        //************** Tř.13 a,b,c zdarma **************
        var price4 = new FeeEntranceDetail
        {
            Id = ++feeEntranceDetailId,
            ExhibitionId = exhibition.Id,
            MinCount = 1,
            MaxCount = 2,
            PriceKc = 0,
            PriceEur = 0,
            MaxNumberOfCats = int.MaxValue,
            MinNumberOfCats = 1
        };
        tupleList.Add((price4, "13a"));
        tupleList.Add((price4, "13b"));
        tupleList.Add((price4, "13c"));

        //************** Tř.14 (domácí kočky), Tř.15 (mimo soutěž) 600/1000 Kč**************
        var price5 = new FeeEntranceDetail
        {
            Id = ++feeEntranceDetailId,
            ExhibitionId = exhibition.Id,
            MinCount = 1,
            MaxCount = 1,
            PriceKc = 600,
            PriceEur = 25,
            MaxNumberOfCats = int.MaxValue,
            MinNumberOfCats = 1
        };
        foreach (var group in new List<string> { "14", "15" }) tupleList.Add((price5, group));

        var price6 = new FeeEntranceDetail
        {
            Id = ++feeEntranceDetailId,
            ExhibitionId = exhibition.Id,
            MinCount = 2,
            MaxCount = 2,
            PriceKc = 1000,
            PriceEur = 40,
            MaxNumberOfCats = int.MaxValue,
            MinNumberOfCats = 1
        };
        foreach (var group in new List<string> { "14", "15" }) tupleList.Add((price6, group));

        //************** Tř.16 (vrhy) 800/1400 Kč **************
        var price7 = new FeeEntranceDetail
        {
            Id = ++feeEntranceDetailId,
            ExhibitionId = exhibition.Id,
            MinCount = 1,
            MaxCount = 1,
            PriceKc = 800,
            PriceEur = 35,
            MaxNumberOfCats = int.MaxValue,
            MinNumberOfCats = 1
        };
        tupleList.Add((price7, "16"));

        var price8 = new FeeEntranceDetail
        {
            Id = ++feeEntranceDetailId,
            ExhibitionId = exhibition.Id,
            MinCount = 2,
            MaxCount = 2,
            PriceKc = 1400,
            PriceEur = 60,
            MaxNumberOfCats = int.MaxValue,
            MinNumberOfCats = 1
        };
        tupleList.Add((price8, "16"));

        //************** Tř.17 (veteráni) 400/700 Kč **************
        var price9 = new FeeEntranceDetail
        {
            Id = ++feeEntranceDetailId,
            ExhibitionId = exhibition.Id,
            MinCount = 1,
            MaxCount = 1,
            PriceKc = 400,
            PriceEur = 60,
            MaxNumberOfCats = int.MaxValue,
            MinNumberOfCats = 1
        };
        tupleList.Add((price9, "17"));

        var price10 = new FeeEntranceDetail
        {
            Id = ++feeEntranceDetailId,
            ExhibitionId = exhibition.Id,
            MinCount = 2,
            MaxCount = 2,
            PriceKc = 700,
            PriceEur = 60,
            MaxNumberOfCats = int.MaxValue,
            MinNumberOfCats = 1
        };
        tupleList.Add((price10, "17"));

        //************** Třetí a další kočka stejného majitele 600/900 Kč **************
        var price3 = new FeeEntranceDetail
        {
            Id = ++feeEntranceDetailId,
            ExhibitionId = exhibition.Id,
            MinCount = 1,
            MaxCount = 1,
            PriceKc = 600,
            PriceEur = 50,
            MaxNumberOfCats = int.MaxValue,
            MinNumberOfCats = 3
        };
        for (var i = 0; i < 13; i++) tupleList.Add((price3, i.ToString()));
        tupleList.Add((price3, "13a"));
        tupleList.Add((price3, "13b"));
        tupleList.Add((price3, "13c"));
        tupleList.Add((price3, "14"));
        tupleList.Add((price3, "15"));
        tupleList.Add((price3, "16"));
        tupleList.Add((price3, "17"));

        var price31 = new FeeEntranceDetail
        {
            Id = ++feeEntranceDetailId,
            ExhibitionId = exhibition.Id,
            MinCount = 2,
            MaxCount = 2,
            PriceKc = 900,
            PriceEur = 50,
            MaxNumberOfCats = int.MaxValue,
            MinNumberOfCats = 3
        };
        for (var i = 0; i < 13; i++) tupleList.Add((price31, i.ToString()));
        tupleList.Add((price31, "13a"));
        tupleList.Add((price31, "13b"));
        tupleList.Add((price31, "13c"));
        tupleList.Add((price31, "14"));
        tupleList.Add((price31, "15"));
        tupleList.Add((price31, "16"));
        tupleList.Add((price31, "17"));

        modelBuilder.Entity<FeeEntranceDetail>().HasData(
            price1, price2, price4, price5, price6, price7, price8, price9, price10, price3, price31
        );

        modelBuilder.Entity<ManyToManyMapper<FeeEntranceDetail>>().HasData(
            tupleList
                .Select(x => new ManyToManyMapper<FeeEntranceDetail>(++manyToManyId, x.Item1.Id, x.Item2))
                .ToList()
        );
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        SetUpDbScheme(modelBuilder);
        SetUpObjects(modelBuilder);
    }
}