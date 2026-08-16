using Microsoft.AspNetCore.Mvc;
using SGTS.Business.Interfaces;
using SGTS.Web.Controllers.Base;

namespace SGTS.Web.Controllers.Api;

public class PrioridadController : BaseController
{
    private readonly IPrioridadService _prioridadService;

    public PrioridadController(IPrioridadService prioridadService)
    {
        _prioridadService = prioridadService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllPrioridades()
    {

        var prioridades = await _prioridadService.GetAllPrioridadesAsync();

        return Success(prioridades);
    }
}