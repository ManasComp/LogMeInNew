using LogMeIn.Models.Models;

namespace LogMeIn.Models;

public class GroupInitializer
{
    private static bool isNon(CatRegistration registration)
    {
        return registration.Cat.Ems.ToLower().Contains("non");
    }

    public static List<Group<CatRegistration>> GetGroups()
    {
        var actualDate = DateTime.Now;
        var id = 0;
        Func<CatRegistration, bool> isHomeCat = registration => registration.Cat.IsHomeCat;
        var list = new List<Group<CatRegistration>>
        {
            new()
            {
                Name = "EUROPA CHAMPION",
                Filter = catRegistration =>
                    !isHomeCat(catRegistration) && !catRegistration.Cat.Neutered && !isNon(catRegistration),
                GroupId = "1",
                Id = ++id
            },
            new()
            {
                Name = "EUROPA PREMIOR",
                Filter = catRegistration =>
                    !isHomeCat(catRegistration) && !catRegistration.Cat.Neutered && !isNon(catRegistration),
                GroupId = "2",
                Id = ++id
            },
            new()
            {
                Name = "Gr. Int. Champion (CACE)",
                Filter = catRegistration =>
                    !isHomeCat(catRegistration) && !catRegistration.Cat.Neutered && !isNon(catRegistration),
                GroupId = "3",
                Id = ++id
            },
            new()
            {
                Name = "Gr. Int. Premior (CAPE)",
                Filter = catRegistration =>
                    !isHomeCat(catRegistration) && !catRegistration.Cat.Neutered && !isNon(catRegistration),
                GroupId = "4",
                Id = ++id
            },
            new()
            {
                Name = "Internationaler Champion (CAGCIB)",
                Filter = catRegistration =>
                    !isHomeCat(catRegistration) && !catRegistration.Cat.Neutered && !isNon(catRegistration),
                GroupId = "5",
                Id = ++id
            },
            new()
            {
                Name = "Internationaler Premior (CAGPIB)",
                Filter = catRegistration =>
                    !isHomeCat(catRegistration) && !catRegistration.Cat.Neutered && !isNon(catRegistration),
                GroupId = "6",
                Id = ++id
            },
            new()
            {
                Name = "Champion (CACIB)",
                Filter = catRegistration =>
                    !isHomeCat(catRegistration) && !catRegistration.Cat.Neutered && !isNon(catRegistration),
                GroupId = "7",
                Id = ++id
            },
            new()
            {
                Name = "Premior (CAPIB)",
                Filter = catRegistration =>
                    !isHomeCat(catRegistration) && !catRegistration.Cat.Neutered && !isNon(catRegistration),
                GroupId = "8",
                Id = ++id
            },
            new()
            {
                Name = "Otevřená (CAC)",
                Filter = catRegistration => !isHomeCat(catRegistration) && !catRegistration.Cat.Neutered,
                GroupId = "9",
                Id = ++id
            },
            new()
            {
                Name = "Kastráti (CAP)",
                Filter = catRegistration => !isHomeCat(catRegistration) && catRegistration.Cat.Neutered,
                GroupId = "10",
                Id = ++id
            },
            new()
            {
                Name = "6-10 měsíců",
                Filter = registration =>
                    actualDate - registration.Cat.BirthDate >= TimeSpan.FromDays(6.0 / 12 * 365.2425)
                    && actualDate - registration.Cat.BirthDate <= TimeSpan.FromDays(10.0 / 12 * 365.2425) &&
                    !isHomeCat(registration) && !registration.Cat.Neutered,
                GroupId = "11",
                Id = ++id
            },
            new()
            {
                Name = "3-6 měsíců",
                Filter = registration =>
                    actualDate - registration.Cat.BirthDate >= TimeSpan.FromDays(3.0 / 12 * 365.2425)
                    && actualDate - registration.Cat.BirthDate <= TimeSpan.FromDays(6.0 / 12 * 365.2425) &&
                    !isHomeCat(registration) && !registration.Cat.Neutered,
                GroupId = "12",
                Id = ++id
            },
            new()
            {
                Name = "Novici",
                Filter = registration =>
                    actualDate - registration.Cat.BirthDate >= TimeSpan.FromDays(10.0 / 12 * 365.2425) &&
                    !isHomeCat(registration) && !registration.Cat.Neutered && !isNon(registration),
                GroupId = "13a",
                Id = ++id
            },
            new()
            {
                Name = "Kontrolní třída",
                Filter = catRegistration =>
                    !isHomeCat(catRegistration) && !catRegistration.Cat.Neutered && !isNon(catRegistration),
                GroupId = "13b",
                Id = ++id
            },
            new()
            {
                Name = "Ověřovací třída",
                Filter = catRegistration =>
                    !isHomeCat(catRegistration) && !catRegistration.Cat.Neutered && !isNon(catRegistration),
                GroupId = "13c",
                Id = ++id
            },
            new()
            {
                Name = "Domácí kočky",
                Filter = catRegistration =>
                    isHomeCat(catRegistration) && !catRegistration.Cat.Neutered && !isNon(catRegistration),
                GroupId = "14",
                Id = ++id
            },
            new()
            {
                Name = "Mimo soutěž",
                Filter = catRegistration =>
                    !isHomeCat(catRegistration) && !catRegistration.Cat.Neutered && !isNon(catRegistration),
                GroupId = "15",
                Id = ++id
            },
            new()
            {
                Name = "Vrhy (min. 3) ",
                Filter = catRegistration =>
                    !isHomeCat(catRegistration) && !catRegistration.Cat.Neutered && !isNon(catRegistration),
                GroupId = "16",
                Id = ++id
            },
            new()
            {
                Name = "Veteran",
                Filter =
                    registration => actualDate - registration.Cat.BirthDate >= TimeSpan.FromDays(10 * 365.2425) &&
                                    !isHomeCat(registration) && !registration.Cat.Neutered && !isNon(registration),
                GroupId = "17",
                Id = ++id
            }
        };

        list.ForEach(x => x.Name = x.Name + " - " + x.GroupId);
        return list;
    }
}