using Microsoft.AspNetCore.Mvc;
using SGMF_backend.Models;
using SGTS.Business.Interfaces;
using SGTS.Models.DTOs;
using SGTS.Web.Controllers.Base;

namespace SGTS.Web.Controllers.Api;

public class DepartamentosController : BaseController
{
    private readonly IDepartamentoService _departamentoService;

    public DepartamentosController(IDepartamentoService departamentoService)
    {
        _departamentoService = departamentoService;
    }

    [HttpPost("query")]
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

    



    [HttpGet("{id}")]
    public async Task<IActionResult> GetDepartamentoById(int id)
    {
        var departamento = await _departamentoService.GetDepartamentoByIdAsync(id);
        return Success(departamento);
    }

    [HttpPost]
    public async Task<IActionResult> CreateDepartamento(DepartamentoDTO departamento)
    {
        await _departamentoService.CreateDepartamentoAsync(departamento);

        return SuccessCreate();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDepartamento(int id)
    {
        await _departamentoService.DeleteDepartamentoAsync(id);
        return SuccessNoContent();
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateDepartamento(int id, DepartamentoDTO departamento)
    {
        if (id != departamento.Id)
        {
            return Fail("ID mismatch between route and body.");
        }

        await _departamentoService.UpdateDepartamentoAsync(departamento);
        return SuccessNoContent();
    }

}
