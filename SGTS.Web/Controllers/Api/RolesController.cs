using Microsoft.AspNetCore.Mvc;
using SGTS.Business.Interfaces.Administracion;
using SGTS.Web.Controllers.Base;

namespace SGTS.Web.Controllers.Api;

public class RolesController : BaseController
{
    private readonly IRolService _rolService;

    public RolesController(IRolService rolService)
    {
        _rolService = rolService;
    }

    [HttpGet()]
    public async Task<IActionResult> GetAllRoles()
    {
        var roles = await _rolService.GetAllRolesAsync();
        return Success(roles);
    }


}