using LogMeIn.Data.Data;
using LogMeIn.Models.Models;
using LogMeIn.Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LogMeIn.Data.DbInitializer;

public class DbInitializer : IDbInitializer
{
    private readonly ApplicationDbContext _db;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly UserManager<ApplicationUser> _userManager;

    public DbInitializer(ApplicationDbContext db, RoleManager<IdentityRole> roleManager,
        UserManager<ApplicationUser> userManager)
    {
        _db = db;
        _roleManager = roleManager;
        _userManager = userManager;
    }

    public void Initialize()
    {
        RunMigrations();
        InitRoles();
        InitUsers();
    }

    private void InitUsers()
    {
        var defaultUsers = new Dictionary<ApplicationUser, Roles>();

        defaultUsers.Add(
            new ApplicationUser(
                "ADMIN@ADMIN.COM",
                "Ondrej",
                "Man",
                "776461453",
                "ADMIN@ADMIN.COM",
                "Czech Republic",
                "Brno",
                "Kabátníkova 9",
                "60200",
                "123456789",
                new DateTime(1999, 1, 1).ToUniversalTime(),
                "9",
                "kocky brno", true)
            , Roles.RoleAdmin);
        defaultUsers.Add(
            new ApplicationUser(
                "ADMIN1@ADMIN.COM",
                "Ondrej",
                "Man",
                "776461453",
                "ADMIN@ADMIN.COM",
                "Czech Republic",
                "Brno",
                "Kabátníkova 9",
                "60200",
                "123456789",
                new DateTime(1999, 1, 1).ToUniversalTime(),
                "9",
                "kocky brno", true)
            , Roles.RoleAdmin);
        defaultUsers.Add(
            new ApplicationUser(
                "ADMIN2@ADMIN.COM",
                "Ondrej",
                "Man",
                "776461453",
                "ADMIN@ADMIN.COM",
                "Czech Republic",
                "Brno",
                "Kabátníkova 9",
                "60200",
                "123456789",
                new DateTime(1999, 1, 1).ToUniversalTime(),
                "9",
                "kocky brno", true)
            , Roles.RoleAdmin);
        defaultUsers.Add(
            new ApplicationUser(
                "ADMIN3@ADMIN.COM",
                "Ondrej",
                "Man",
                "776461453",
                "ADMIN@ADMIN.COM",
                "Czech Republic",
                "Brno",
                "Kabátníkova 9",
                "60200",
                "123456789",
                new DateTime(1999, 1, 1).ToUniversalTime(),
                "9",
                "kocky brno", true)
            , Roles.RoleAdmin);
        defaultUsers.Add(
            new ApplicationUser(
                "ADMIN4@ADMIN.COM",
                "Ondrej",
                "Man",
                "776461453",
                "ADMIN@ADMIN.COM",
                "Czech Republic",
                "Brno",
                "Kabátníkova 9",
                "60200",
                "123456789",
                new DateTime(1999, 1, 1).ToUniversalTime(),
                "9",
                "kocky brno", true)
            , Roles.RoleAdmin);

        defaultUsers.Add(
            new ApplicationUser(
                "USER@USER.COM",
                "Ondrej",
                "Man",
                "776461453",
                "USER@USER.COM",
                "Czech Republic",
                "Brno",
                "Kabátníkova",
                "60200",
                "123456789",
                new DateTime(1999, 1, 1).ToUniversalTime(),
                "9",
                "kocky brno"
                , true)
            , Roles.RoleUser);
        defaultUsers.Add(
            new ApplicationUser(
                "USER1@USER.COM",
                "Ondrej",
                "Man",
                "776461453",
                "USER@USER.COM",
                "Czech Republic",
                "Brno",
                "Kabátníkova",
                "60200",
                "123456789",
                new DateTime(1999, 1, 1).ToUniversalTime(),
                "9",
                "kocky brno"
                , true)
            , Roles.RoleUser);
        defaultUsers.Add(
            new ApplicationUser(
                "USER2@USER.COM",
                "Ondrej",
                "Man",
                "776461453",
                "USER@USER.COM",
                "Czech Republic",
                "Brno",
                "Kabátníkova",
                "60200",
                "123456789",
                new DateTime(1999, 1, 1).ToUniversalTime(),
                "9",
                "kocky brno"
                , true)
            , Roles.RoleUser);
        defaultUsers.Add(
            new ApplicationUser(
                "USER3@USER.COM",
                "Ondrej",
                "Man",
                "776461453",
                "USER@USER.COM",
                "Czech Republic",
                "Brno",
                "Kabátníkova",
                "60200",
                "123456789",
                new DateTime(1999, 1, 1).ToUniversalTime(),
                "9",
                "kocky brno"
                , true)
            , Roles.RoleUser);
        defaultUsers.Add(
            new ApplicationUser(
                "USER3@USER.COM",
                "Ondrej",
                "Man",
                "776461453",
                "USER@USER.COM",
                "Czech Republic",
                "Brno",
                "Kabátníkova",
                "60200",
                "123456789",
                new DateTime(1999, 1, 1).ToUniversalTime(),
                "9",
                "kocky brno"
                , true)
            , Roles.RoleUser);

        defaultUsers.Add(
            new ApplicationUser(
                "USER4@USER.COM",
                "Ondrej",
                "Man",
                "776461453",
                "USER@USER.COM",
                "Czech Republic",
                "Brno",
                "Kabátníkova",
                "60200",
                "123456789",
                new DateTime(1999, 1, 1).ToUniversalTime(),
                "9",
                "kocky brno"
                , true)
            , Roles.RoleUser);
        defaultUsers.Add(
            new ApplicationUser(
                "USER5@USER.COM",
                "Ondrej",
                "Man",
                "776461453",
                "USER@USER.COM",
                "Czech Republic",
                "Brno",
                "Kabátníkova",
                "60200",
                "123456789",
                new DateTime(1999, 1, 1).ToUniversalTime(),
                "9",
                "kocky brno"
                , true)
            , Roles.RoleUser);

        defaultUsers.Add(
            new ApplicationUser(
                "USER6@USER.COM",
                "Ondrej",
                "Man",
                "776461453",
                "USER@USER.COM",
                "Czech Republic",
                "Brno",
                "Kabátníkova",
                "60200",
                "123456789",
                new DateTime(1999, 1, 1).ToUniversalTime(),
                "9",
                "kocky brno"
                , true)
            , Roles.RoleUser);
        defaultUsers.Add(
            new ApplicationUser(
                "USER7@USER.COM",
                "Ondrej",
                "Man",
                "776461453",
                "USER@USER.COM",
                "Czech Republic",
                "Brno",
                "Kabátníkova",
                "60200",
                "123456789",
                new DateTime(1999, 1, 1).ToUniversalTime(),
                "9",
                "kocky brno"
                , true)
            , Roles.RoleUser);
        defaultUsers.Add(
            new ApplicationUser(
                "USER8@USER.COM",
                "Ondrej",
                "Man",
                "776461453",
                "USER@USER.COM",
                "Czech Republic",
                "Brno",
                "Kabátníkova",
                "60200",
                "123456789",
                new DateTime(1999, 1, 1).ToUniversalTime(),
                "9",
                "kocky brno"
                , true)
            , Roles.RoleUser);
        defaultUsers.Add(
            new ApplicationUser(
                "USER9@USER.COM",
                "Ondrej",
                "Man",
                "776461453",
                "USER@USER.COM",
                "Czech Republic",
                "Brno",
                "Kabátníkova",
                "60200",
                "123456789",
                new DateTime(1999, 1, 1).ToUniversalTime(),
                "9",
                "kocky brno"
                , true)
            , Roles.RoleUser);

        const string password = "Admin123*";

        var dbUsers = _db.ApplicationUsers!.ToList();
        foreach (var pair in defaultUsers.Where(pair => dbUsers.All(u => u.Email != pair.Key.Email)))
        {
            _userManager.CreateAsync(pair.Key, password).GetAwaiter().GetResult();

            var user = _userManager.Users.FirstOrDefault(u => u.Email == pair.Key.Email) ??
                       throw new InvalidOperationException();
            _userManager.AddToRoleAsync(user, pair.Value.ToString()).GetAwaiter().GetResult();
        }
    }


    private void InitRoles()
    {
        var values = Enum.GetValues(typeof(Roles)).Cast<Roles>();
        foreach (var role in values)
            if (!_roleManager.RoleExistsAsync(role.ToString()).GetAwaiter().GetResult())
                _roleManager.CreateAsync(new IdentityRole(role.ToString())).GetAwaiter().GetResult();
    }

    private void RunMigrations()
    {
        try
        {
            if (_db.Database.GetPendingMigrations().Any()) _db.Database.Migrate();
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}