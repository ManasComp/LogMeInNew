using LogMeIn.Areas.Visitor.Views.ExhibitionHome;
using LogMeIn.Controllers;
using LogMeIn.Data.Repositories.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace LogMeIn.Areas.Visitor.Controllers;

[Area("Visitor")]
public class ExhibitionHomeController : GController
{
    public ExhibitionHomeController(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }


    // GET
    public IActionResult Index()
    {
        var a = UnitOfWork.Exhibition.GetAll(includeProperties: "Organization,Location").ToList();
        a.ForEach(x =>
        {
            x.StartDate = x.StartDate.ToLocalTime();
            x.EndDate = x.EndDate.ToLocalTime();
        });
        return View(a[0]);
    }

    public IActionResult RegistrateOrLogin(string? returnUrl)
    {
        if (User.Identity is { IsAuthenticated: true })
            return RedirectToAction("CreateCatRegistration", "CatRegistration");

        var a = UnitOfWork.Exhibition.Get(x => x.Id == 1);
        var vm = new IndexVm
        {
            Name = a.Name,
            ReturnUrl = returnUrl
        };
        
        return View(vm);
    }
}