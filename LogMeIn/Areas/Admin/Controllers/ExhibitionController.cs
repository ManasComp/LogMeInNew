using LogMeIn.Controllers;
using LogMeIn.Data.Repositories.IRepositories;
using LogMeIn.Models.Models;
using LogMeIn.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LogMeIn.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = nameof(Roles.RoleAdmin))]
public class ExhibitionController : GController
{
    public ExhibitionController(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    public IActionResult Index()
    {
        var categories = UnitOfWork.Exhibition.GetAll().ToList();
        return View(categories);
    }

    public IActionResult Upsert(int? catRegistrationId)
    {
        return View(new Exhibition());
    }


    [HttpPost]
    public IActionResult Upsert(Exhibition exhibition)
    {
        if (ModelState.IsValid)
        {
            exhibition.StartDate = exhibition.StartDate.ToUniversalTime();
            exhibition.EndDate = exhibition.EndDate.ToUniversalTime();
            if (exhibition.Id != 0)
                UnitOfWork.Exhibition.Update(exhibition);
            else
                UnitOfWork.Exhibition.Add(exhibition);

            UnitOfWork.Save();
            TempData["success"] = "Exhibition has been saved";
            return RedirectToAction("Index");
        }

        return RedirectToAction("Index");
    }


    #region API CALLS

    [HttpGet]
    public IActionResult GetAll()
    {
        return Json(new { data = UnitOfWork.Exhibition.GetAll().ToList() });
    }

    [HttpDelete]
    public IActionResult Delete(int? catRegistrationId)
    {
        if (catRegistrationId == null || catRegistrationId == 0)
            return Json(new { success = false, message = "Invalid id" });

        var product = UnitOfWork.Exhibition.Get(u => u.Id == catRegistrationId);
        if (product == null)
            return Json(new { success = false, message = "Record not found" });

        UnitOfWork.Exhibition.Remove(product);
        UnitOfWork.Save();
        return Json(new { success = true, message = "Delete successful" });
    }

    #endregion
}