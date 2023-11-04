using AutoMapper;
using LogMeIn.Data.Repositories.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace LogMeIn.Controllers;

public abstract class GController : Controller
{
    protected readonly IUnitOfWork UnitOfWork;
    protected readonly IMapper Mapper;

    protected GController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        UnitOfWork = unitOfWork;
        Mapper = mapper;
    }

    protected GController(IUnitOfWork unitOfWork)
    {
        UnitOfWork = unitOfWork;
    }
}