using LogMeIn.Data.Repositories.IRepositories;
using LogMeIn.Models;
using LogMeIn.Models.Models;
using LogMeIn.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LogMeIn.Controllers;

public class ExhibitionMapper : GController
{
    public ExhibitionMapper(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    private DateTime[] GetDatesBetween(DateTime startDate, DateTime endDate)
    {
        return Enumerable.Range(0,
                1 + endDate.Subtract(startDate).Days)
            .Select(offset => startDate.AddDays(offset))
            .ToArray();
    }

    public ExhibitionVm HandleSHit(ExhibitionVm vm, CatRegistration catRegistration)
    {
        var filteredGroups = GroupInitializer.GetGroups()
            .Where(x => x.Filter(catRegistration))
            .Select(y => new SelectListItem
            {
                Text = y.Name,
                Value = y.GroupId
            }).ToArray();
        vm.Groups = filteredGroups;

        for (var i = 0; i < catRegistration.AttendanceOnDays.Count; i++)
        {
            var day = catRegistration.AttendanceOnDays.ElementAt(i);
            day.Visited = vm.AttendanceOnDays[i][0].IsChecked;
        }

        vm.Days = GetDatesBetween(catRegistration.PersonRegistration.Exhibition.StartDate,
                catRegistration.PersonRegistration.Exhibition.EndDate)
            .Select(x => x.ToString("dd.MM.yyyy")).ToList();

        return vm;
    }

    public void SaveModel(ExhibitionVm vm, CatRegistration catRegistration)
    {
        var id = vm.CatRegistrationId;


        if (catRegistration == null)
            throw new Exception("");

        if (catRegistration == null)
            throw new Exception("");
        catRegistration.Note = vm.Note;

        var days = catRegistration.AttendanceOnDays;
        for (var i = 0; i < days.Count; i++)
        {
            var day = days.ElementAt(i);
            // TODO do new class
            day.Visited = vm.AttendanceOnDays[i][0].IsChecked;
            UnitOfWork.Day.Update(day);
            var dayFees = day.DayFees;
            for (var j = 0; j < dayFees.Count; j++)
            {
                var dayFee = dayFees.ElementAt(j);
                dayFee.bought = vm.AttendanceOnDays[i][j + 1].IsChecked;
                UnitOfWork.DayFees.Update(dayFee);
            }
        }

        var catCompleteFees = catRegistration.CompleteFees;
        for (var i = 0; i < catCompleteFees.Count; i++)
        {
            var catFee = catCompleteFees
                .Where(x => x.FeeId == vm.CatCompleteFees[i].FeeId).FirstOrDefault();
            catFee.bought = vm.CatCompleteFees[i].IsChecked;
            UnitOfWork.CatFees.Update(catFee);
        }

        var list = vm.SelectedId.Select(x => new ManyToManyMapper<CatRegistration>(catRegistration.Id, x))
            .ToList();
        UnitOfWork.ManyToManyCat
            .RemoveRange(UnitOfWork.ManyToManyCat
                .GetAll(x => x.AttributeId == catRegistration.Id));
        list.ForEach(x =>
            UnitOfWork.ManyToManyCat.AddAndSave(x));
        catRegistration.SelectedGroups = list;
        catRegistration.LastStep = vm.StepId;
        UnitOfWork.CatRegistration.Update(catRegistration);

        UnitOfWork.Save();
    }

    public ExhibitionVm ConvertToDto(int catRegistrationId)
    {
        var catRegistration = UnitOfWork.CatRegistration.GetAsQuery(x => x.Id == catRegistrationId)
            .Include(x => x.CompleteFees)
            .ThenInclude(x => x.Fee).AsNoTracking()
            .Include(x => x.AttendanceOnDays)
            .ThenInclude(x => x.DayFees)
            .ThenInclude(x => x.Fee).AsNoTracking()
            .Include(x => x.PersonRegistration)
            .ThenInclude(x => x.CompleteFees)
            .ThenInclude(x => x.Fee)
            .Include(x => x.PersonRegistration)
            .ThenInclude(x => x.Exhibition).AsNoTracking()
            .Include(x => x.Cat).AsNoTracking()
            .Include(x => x.PersonRegistration)
            .ThenInclude(x => x.PersonEnumFee)
            .ThenInclude(x => x.Fee)
            .ThenInclude(x => x.FeeRecords).AsNoTracking()
            .Include(x => x.SelectedGroups)
            .AsNoTracking()
            .FirstOrDefault();
        var stepVm = new ExhibitionVm();
        stepVm.CatRegistrationId = catRegistration.Id;
        stepVm.StepId = catRegistration.Cat.IsHomeCat ? 1 : 3;

        stepVm.SelectedId = catRegistration.SelectedGroups.Select(x => x.GroupId).ToArray();
        stepVm.Note = catRegistration.Note;
        stepVm.CatCompleteFees = GetAsVm(catRegistration.CompleteFees);

        stepVm.AttendanceOnDays = GetAsVm(catRegistration.AttendanceOnDays);

        ///same
        stepVm.Groups = GroupInitializer.GetGroups()
            .Where(x => x.Filter(catRegistration))
            .Select(y => new SelectListItem
            {
                Text = y.Name,
                Value = y.GroupId
            });

        stepVm.Days = GetDatesBetween(catRegistration.PersonRegistration.Exhibition.StartDate,
                catRegistration.PersonRegistration.Exhibition.EndDate)
            .Select(x => x.ToString("dd.MM.yyyy")).ToList();

        stepVm.isHomeCat = catRegistration.Cat.IsHomeCat;

        return stepVm;
    }


    private CheckBox[] GetAsVm(List<StoredFees<CatRegistration, Fee, bool>> completeFees)
    {
        var CatCompleteFees = new CheckBox[completeFees.Count];
        completeFees = completeFees.OrderBy(x => x.Fee.Order).ToList();
        for (var i = 0; i < completeFees.Count; i++)
            CatCompleteFees[i] = new CheckBox
            {
                Id = i,
                LabelName = completeFees[i].Fee.Name,
                IsChecked = completeFees[i].bought,
                ExhibitionStoreId = completeFees[i].Id,
                JavascriptId = completeFees[i].Fee.JavascriptId,
                FeeId = completeFees[i].Fee.Id
            };
        return CatCompleteFees;
    }

    private List<List<CheckBox>> GetAsVm(ICollection<Day<CatRegistration>> AAttendanceOnDays)
    {
        var _attendanceOnDays = new List<List<CheckBox>>();
        for (var i = 0; i < AAttendanceOnDays.Count; i++)
        {
            var day = AAttendanceOnDays.ElementAt(i);
            var dayFees = day.DayFees;
            var dayCheckBoxes = new List<CheckBox>();
            dayCheckBoxes.Add(new CheckBox
            {
                Id = i,
                LabelName = "Účast",
                IsChecked = day.Visited,
                ExhibitionStoreId = day.Id,
                JavascriptId = "attendance" + "_" + i
            });
            for (var j = 0; j < dayFees.Count; j++)
                dayCheckBoxes.Add(new CheckBox
                {
                    Id = j,
                    LabelName = dayFees[j].Fee.Name,
                    IsChecked = dayFees[j].bought,
                    ExhibitionStoreId = dayFees[j].Id,
                    JavascriptId = dayFees[j].Fee.JavascriptId + "_" + i,
                    FeeId = dayFees[j].Fee.Id
                });
            _attendanceOnDays.Add(dayCheckBoxes);
        }

        return _attendanceOnDays;
    }

    public CatRegistration GetCatRegistration(int catRegistrationId)
    {
        var catRegistration =
            UnitOfWork.CatRegistration.GetAsQuery(x => x.Id == catRegistrationId)
                .Include(x => x.CompleteFees)
                .AsNoTracking()
                .Include(x => x.AttendanceOnDays)
                .ThenInclude(x => x.DayFees)
                .AsNoTracking()
                .Include(x => x.PersonRegistration)
                .ThenInclude(x => x.CompleteFees)
                .AsNoTracking()
                .Include(x => x.PersonRegistration)
                .ThenInclude(x => x.PersonEnumFee)
                .AsNoTracking()
                .Include(x => x.Cat).AsNoTracking()
                .Include(x => x.PersonRegistration)
                .ThenInclude(x => x.Exhibition)
                .FirstOrDefault();
        return catRegistration;
    }
}