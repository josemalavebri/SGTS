using Microsoft.AspNetCore.Mvc;
using SGTS.Business.Interfaces;
using SGTS.Web.Controllers.Base;

namespace SGTS.Web.Controllers.Api;

public class UsuarioAsignacionController : BaseController
{
    private readonly IUsuarioAsignacionService _usuarioAsignacionService;

    public UsuarioAsignacionController(IUsuarioAsignacionService usuarioAsignacionService)
    {
        _usuarioAsignacionService = usuarioAsignacionService;
    }

    [HttpPost("query")]
    public async Task<IActionResult> GetAllUsuarioAsignaciones()
    {


        return Ok();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUsuarioAsignacionById(int id)
    {
        var usuarioAsignacion = await _usuarioAsignacionService.GetByIdAsync(id);
        return Success(usuarioAsignacion);
    }
}