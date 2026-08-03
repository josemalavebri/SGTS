using Microsoft.AspNetCore.Mvc;
using SGMF_backend.Models;
using SGTS.Business.Interfaces;
using SGTS.Models.DTOs;
using SGTS.Web.Controllers.Base;

namespace SGTS.Web.Controllers.Api;

public class AdministracionController : BaseController
{
    private readonly IDepartamentoService _departamentoService;
    private readonly IUsuarioAsignacionService _usuarioAsignacionService;

    public AdministracionController(IDepartamentoService departamentoService, IUsuarioAsignacionService usuarioAsignacionService)
    {
        _departamentoService = departamentoService;
        _usuarioAsignacionService = usuarioAsignacionService;
    }

    [HttpPost("departamentos/query")]
    public async Task<IActionResult> GetAllDepartamentos(DataTableRequestDTO request)
    {
        int pageNumber = (request.Start / request.Length) + 1;
        var departamentos = await _departamentoService.GetAllDepartamentosAsync(request);
        int pageSize = request.Length;

        var pagination = new Pagination
        {
            Drawn = request.Draw,
            PageNumber = pageNumber,
            PageSize = pageSize,
            TotalRecords = departamentos.TotalRecords,
            TotalRecordsFiltered = departamentos.TotalRecordsFiltered
        };

        return Success(departamentos.Items, pagination);
    }

    [HttpGet("departamentos/all")]
    public async Task<IActionResult> GetAllDepartamentos()
    {
        var departamentos = await _departamentoService.GetAllDepartamentos();
        return Success(departamentos);
    }

    [HttpGet("departamentos/{id}")]
    public async Task<IActionResult> GetDepartamentoById(int id)
    {
        var departamento = await _departamentoService.GetDepartamentoByIdAsync(id);
        return Success(departamento);
    }

    [HttpPost("departamentos")]
    public async Task<IActionResult> CreateDepartamento(DepartamentoDTO departamento)
    {
        await _departamentoService.CreateDepartamentoAsync(departamento);

        return SuccessCreate();
    }

    [HttpDelete("departamentos/{id}")]
    public async Task<IActionResult> DeleteDepartamento(int id)
    {
        await _departamentoService.DeleteDepartamentoAsync(id);
        return SuccessNoContent();
    }

    [HttpPut("departamentos/{id}")]
    public async Task<IActionResult> UpdateDepartamento(int id, DepartamentoDTO departamento)
    {
        if (id != departamento.Id)
        {
            return Fail("ID mismatch between route and body.");
        }

        await _departamentoService.UpdateDepartamentoAsync(departamento);
        return SuccessNoContent();
    }



    [HttpPost("usuariosAsignaciones/query")]
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

    [HttpGet("usuariosAsignaciones/{id}")]
    public async Task<IActionResult> GetUsuarioAsignacionById(int id)
    {
        var usuarioAsignacion = await _usuarioAsignacionService.GetByIdAsync(id);
        return Success(usuarioAsignacion);
    }

}
