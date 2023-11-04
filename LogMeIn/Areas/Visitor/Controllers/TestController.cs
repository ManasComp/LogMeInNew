using System.Web.Mvc;
using LogMeIn.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Controller = Microsoft.AspNetCore.Mvc.Controller;

namespace LogMeIn.Areas.Visitor.Controllers;

[Area("Visitor")]
public class TestController : Controller
{
    public IActionResult Index(int? catRegistrationId)
    {
        var model = new StepVm<TrestModel>();
        model.Data = new TrestModel();
        return View(model);
    }

    [Microsoft.AspNetCore.Mvc.HttpPost]
    public IActionResult Index(StepVm<TrestModel> model)
    {
        return View(model);
    }

    [Microsoft.AspNetCore.Mvc.AcceptVerbs("GET", "POST")]
    [Microsoft.AspNetCore.Mvc.AcceptVerbs("GET", "POST")]
    public IActionResult VerifyEmail(string email)
    {
        if (email == "test") return Json($"Email {email} is already in use.");

        return Json(true, JsonRequestBehavior.AllowGet);
    }
}

public class TrestModel
{
    [Microsoft.AspNetCore.Mvc.Remote(areaName: "Visitor", controller: "Test", action: "VerifyEmail")]
    public string Email { get; set; }

    public string Name { get; set; }
}