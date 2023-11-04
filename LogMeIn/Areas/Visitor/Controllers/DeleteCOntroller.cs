using LogMeIn.Controllers;
using LogMeIn.Data.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace LogMeIn.Areas.Visitor.Controllers;

public class DeleteCOntroller : GController
{
    public DeleteCOntroller(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    public void DeletePersonReg(int id)
    {
        var personRegistration = UnitOfWork.PersonRegistration.GetAsQuery(x => x.Id == id)
            .Include(x => x.CompleteFees)
            .Include(x => x.CatRegistrations)
            .Include(x => x.PersonEnumFee).FirstOrDefault();
        if (personRegistration == null)
            return;

        foreach (var fee in personRegistration.CompleteFees) UnitOfWork.PersonFees.Remove(fee);

        foreach (var catRegistration in personRegistration.CatRegistrations)
            UnitOfWork.CatRegistration.Remove(catRegistration);

        foreach (var fee in personRegistration.PersonEnumFee) UnitOfWork.EnumFees.Remove(fee);

        UnitOfWork.PersonRegistration.Remove(personRegistration);
    }

    public void DeleteExhibitedCatt(int id)
    {
        var x = UnitOfWork.ExhibitedCatRepository.GetAsQuery(x => x.Id == id)
            .Include(x => x.Father)
            .Include(x => x.Mother)
            .FirstOrDefault();
        if (x == null)
            return;
        if (x.Father != null)
            UnitOfWork.Cat.Remove(x.Father);
        if (x.Mother != null)
            UnitOfWork.Cat.Remove(x.Mother);
        UnitOfWork.ExhibitedCatRepository.Remove(x);
    }

    public void DeleteCatRegistration(int id)
    {
        var x = UnitOfWork.CatRegistration.GetAsQuery(x => x.Id == id)
            .Include(x => x.Cat)
            .FirstOrDefault();
        if (x == null)
            return;
        DeleteExhibitedCatt(x.Cat.Id);
        UnitOfWork.CatRegistration.Remove(x);
    }
    
    public void deleteOrder(int id)
    {
        var x = UnitOfWork.OrderRepository.GetAsQuery(x => x.Id == id)
            .Include(x => x.PersonRegistration)
            .FirstOrDefault();
        if (x == null)
            return;

        DeletePersonReg(x.PersonRegistration.Id);
        UnitOfWork.OrderRepository.Remove(x);
    }
}