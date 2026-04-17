

using Microsoft.AspNetCore.Mvc;
using SGMF_backend.Models;
using SGTS.Business.Interfaces;
using SGTS.Business.Services;
using SGTS.Models.DTOs;
using SGTS.Web.Controllers.Base;

namespace SGTS.Web.Controllers.Api;

public class ProblemasController(IProblemaService problemaService) : BaseController
{
    private readonly IProblemaService _problemaService = problemaService;

    [HttpPost("query")]
    public async Task<IActionResult> Get([FromBody] DataTableRequest request)
    {
        int pageNumber = (request.Start / request.Length) + 1;
        int pageSize = request.Length;

        var pagedUsuarios = await _problemaService.DataTableQueryService(request);

        var pagination = new Pagination
        {
            Drawn = request.Draw,
            PageNumber = pageNumber,
            PageSize = pageSize,
            TotalRecords = pagedUsuarios.TotalRecords,
            TotalRecordsFiltered = pagedUsuarios.TotalRecordsFiltered
        };

        return Success(pagedUsuarios.Items, pagination);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] ProblemaDtoRequest dto)
    {
        
        await _problemaService.CrearProblema(dto);
        return NoContent();
    }
}
