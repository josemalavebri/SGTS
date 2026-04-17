using Microsoft.AspNetCore.Mvc;
using SGMF_backend.Models;
using SGTS.Business.Interfaces;
using SGTS.Data.Const;
using SGTS.Data.Exceptions;
using SGTS.Models.DTOs;
using SGTS.Web.Controllers.Base;

namespace SGTS.Web.Controllers.Api;

public class UsuariosController(IUsuarioService usuarioService) : BaseController
{
    private readonly IUsuarioService _usuarioService = usuarioService;

    [HttpPost("query")]
    public async Task<IActionResult> Query([FromBody] DataTableRequest request)
    {
        /*  try
         {
             int b = 10;
             int a = b / 0;
             return Ok();
         }
         catch (Exception ex)
         {
             throw new PersistenceException(DataMessages.ERROR_OBTENER, ex);
         } */


        int pageNumber = (request.Start / request.Length) + 1;
        int pageSize = request.Length;

        var pagedUsuarios = await _usuarioService.Query(request);
        Console.WriteLine(pagedUsuarios);
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

    [HttpGet("buscar")]
    public async Task<IActionResult> GetByNombre(string nombre)
    {
        var result = await _usuarioService.ObtenerPorNombre(nombre);
        return Success(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UsuarioDTO usuarioDto)
    {
        usuarioDto.Id = id;
        await _usuarioService.ActualizarUsuario(usuarioDto);

        return SuccessNoContent();
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] UsuarioDTO usuarioDto)
    {
        await _usuarioService.CrearUsuario(usuarioDto);

        return SuccessNoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _usuarioService.EliminarUsuario(id);

        return SuccessNoContent();
    }
}