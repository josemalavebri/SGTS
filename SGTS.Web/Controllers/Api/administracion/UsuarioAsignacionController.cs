using Microsoft.AspNetCore.Mvc;
using SGMF_backend.Models;
using SGTS.Business.Interfaces;
using SGTS.Models.DTOs;
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
    public async Task<IActionResult> GetAllUsuarioAsignaciones(DataTableRequestDTO request)
    {
        int pageNumber = (request.Start / request.Length) + 1;
        var usuarioAsignaciones = await _usuarioAsignacionService.GetAllAsync(request);
        int pageSize = request.Length;

        var pagination = new Pagination
        {
            Drawn = request.Draw,
            PageNumber = pageNumber,
            PageSize = pageSize,
            TotalRecords = usuarioAsignaciones.TotalRecords,
            TotalRecordsFiltered = usuarioAsignaciones.TotalRecordsFiltered
        };

        return Success(usuarioAsignaciones.Items, pagination);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUsuarioAsignacionById(int id)
    {
        var usuarioAsignacion = await _usuarioAsignacionService.GetByIdAsync(id);
        return Success(usuarioAsignacion);
    }
}