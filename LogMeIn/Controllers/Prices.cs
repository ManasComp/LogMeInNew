using LogMeIn.Data.Repositories.IRepositories;
using LogMeIn.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace LogMeIn.Controllers;

public class Prices : GController
{
    private readonly PersonRegistration personRegistration;

    public Prices(IUnitOfWork unitOfWork, int id) : base(unitOfWork)
    {
        personRegistration = UnitOfWork.PersonRegistration.GetAsQuery(x => x.Id == id)
            .Include(x => x.PersonEnumFee)
            .ThenInclude(x => x.Fee)
            .ThenInclude(x => x.FeeRecords)
            .AsNoTracking()
            .Include(x => x.Exhibiter)
            .Include(x => x.CatRegistrations)
            .ThenInclude(x => x.SelectedGroups)
            .Include(x => x.Exhibition)
            .ThenInclude(x => x.Price)
            .ThenInclude(x => x.ExhibitedGroup)
            .Include(x => x.Exhibition)
            .ThenInclude(x => x.Fees)
            .ThenInclude(x => x.FeeDetails)
            .Include(x => x.CatRegistrations)
            .ThenInclude(x => x.AttendanceOnDays)
            .ThenInclude(x => x.DayFees)
            .ThenInclude(x => x.Fee)
            .ThenInclude(x => x.FeeDetails)
            .Include(x => x.CatRegistrations)
            .ThenInclude(x => x.CompleteFees)
            .ThenInclude(x => x.Fee)
            .ThenInclude(x => x.FeeDetails)
            .Include(x => x.CatRegistrations)
            .ThenInclude(x => x.Cat)
            .FirstOrDefault();
    }

    public double getCatPrice(int catRegistrationId)
    {
        var catRegistration =
            personRegistration.CatRegistrations.Where(x => x.Id == catRegistrationId).FirstOrDefault();
        var number = catRegistration
            .AttendanceOnDays.Count(day => day.Visited);
        var list = catRegistration.SelectedGroups.ToList();
        var pricePerDays = catRegistration.PersonRegistration.Exhibition.Price
            .Where(item => item.MinCount <= number && number <= item.MaxCount)
            .Where(item => item.MinNumberOfCats >= catRegistration.CatOrder &&
                           catRegistration.CatOrder <= item.MaxNumberOfCats)
            .Where(item => item.ExhibitedGroup
                .Any(group => list
                    .Exists(x => group.GroupId == x.GroupId)))
            .Select(item => item.PriceKc).Max();

        var prices = catRegistration
            .AttendanceOnDays
            .SelectMany(day => day.DayFees)
            .Where(fee => fee.bought)
            .GroupBy(x => x.Fee.Id)
            .ToDictionary(group => group.Key, group => group.Count());
        var dayFees = catRegistration.PersonRegistration.Exhibition.Fees
            .Where(x => prices.ContainsKey(x.Id))
            .SelectMany(x => x.FeeDetails)
            .Where(x => x.MinCount <= prices[x.Fee.Id] && prices[x.Fee.Id] <= x.MaxCount)
            .Select(x => x.PriceKc)
            .Sum();

        var catbought = catRegistration.CompleteFees.Where(x => x.bought)
            .SelectMany(x => x.Fee.FeeDetails)
            .Where(x => x.MaxCount == x.MinCount && x.MinCount == 1)
            .Select(x => x.PriceKc)
            .Sum();
        catRegistration.Price = dayFees + pricePerDays + catbought;
        var price = catRegistration.Price;

        return price;
    }

    public double getPersonEnumPricer()
    {
        var bought = personRegistration.PersonEnumFee.Select(x => x.bought).ToList();
        var personeEnumPrice = UnitOfWork.FeeRecords
            .GetAll(x => bought.Contains(x.Id))
            .Select(x => x.PriceKc)
            .Sum();
        return personeEnumPrice;
    }

    public double getTotalPices(int catRegistrationId)
    {
        double price = 0;
        price += getPersonEnumPricer();
        foreach (var catRegistration in personRegistration.CatRegistrations.Where(x => x.isDraft(x.Cat.IsHomeCat)))
            price += getCatPrice(catRegistration.Id);
        return price;
    }

    // public void getPrices(int id)
    // {
    //     var catRegistration =
    //         UnitOfWork.CatRegistration.GetAsQuery(x => x.Id == id)
    //             .Include(x => x.CompleteFees)
    //             .ThenInclude(x => x.Fee)
    //             .ThenInclude(x => x.FeeDetails)
    //             .AsNoTracking()
    //             .Include(x => x.AttendanceOnDays)
    //             .ThenInclude(x => x.DayFees)
    //             .ThenInclude(x => x.Fee)
    //             .AsNoTracking()
    //             .Include(x => x.PersonRegistration)
    //             .ThenInclude(x => x.CompleteFees)
    //             .AsNoTracking()
    //             .Include(x => x.PersonRegistration)
    //             .ThenInclude(x => x.PersonEnumFee)
    //             .Include(x => x.PersonRegistration)
    //             .ThenInclude(x => x.Exhibition)
    //             .ThenInclude(x => x.Price)
    //             .ThenInclude(x => x.ExhibitedGroup)
    //             .Include(x => x.PersonRegistration)
    //             .ThenInclude(x => x.Exhibition)
    //             .ThenInclude(x => x.Fees)
    //             .ThenInclude(x => x.FeeDetails)
    //             .Include(x => x.SelectedGroups)
    //             .AsNoTracking()
    //             .Include(x => x.Cat)
    //             .ThenInclude(x => x.Mother)
    //             .Include(x => x.Cat)
    //             .ThenInclude(x => x.Father)
    //             .Include(x => x.PersonRegistration)
    //             .ThenInclude(x => x.Exhibiter)
    //             .Include(x => x.Cat)
    //             .ThenInclude(x => x.Breeder).AsNoTracking()
    //             .FirstOrDefault();
    //
    //     var number = catRegistration
    //         .AttendanceOnDays.Count(day => day.Visited);
    //
    //     var list = catRegistration.SelectedGroups.ToList();
    //     var pricePerDays = catRegistration.PersonRegistration.Exhibition.Price
    //         .Where(item => item.MinCount <= number && number <= item.MaxCount)
    //         .Where(item => item.MinNumberOfCats >= catRegistration.CatOrder &&
    //                        catRegistration.CatOrder <= item.MaxNumberOfCats)
    //         .Where(item => item.ExhibitedGroup
    //             .Any(group => list
    //                 .Exists(x => group.GroupId == x.GroupId)))
    //         .Select(item => item.PriceKc).Max();
    //
    //     var prices = catRegistration
    //         .AttendanceOnDays
    //         .SelectMany(day => day.DayFees)
    //         .Where(fee => fee.bought)
    //         .GroupBy(x => x.Fee.Id)
    //         .ToDictionary(group => group.Key, group => group.Count());
    //     var dayFees = catRegistration.PersonRegistration.Exhibition.Fees
    //         .Where(x => prices.ContainsKey(x.Id))
    //         .SelectMany(x => x.FeeDetails)
    //         .Where(x => x.MinCount <= prices[x.Fee.Id] && prices[x.Fee.Id] <= x.MaxCount)
    //         .Select(x => x.PriceKc)
    //         .Sum();
    //
    //     var catbought = catRegistration.CompleteFees.Where(x => x.bought)
    //         .SelectMany(x => x.Fee.FeeDetails)
    //         .Where(x => x.MaxCount == x.MinCount && x.MinCount == 1)
    //         .Select(x => x.PriceKc)
    //         .Sum();
    //     catRegistration.Price = dayFees + pricePerDays + catbought;
    // }
}