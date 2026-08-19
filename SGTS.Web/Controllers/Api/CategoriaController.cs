using Microsoft.AspNetCore.Mvc;
using SGTS.Business.Interfaces;
using SGTS.Web.Controllers.Base;

namespace SGTS.Web.Controllers.Api;

public class CategoriaController : BaseController
{
    private readonly ICategoriaService _categoriaService;

    public CategoriaController(ICategoriaService categoriaService)
    {
        _categoriaService = categoriaService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCategorias()
    {
        var categorias = await _categoriaService.GetAllCategoriasAsync();

        return Success(categorias);
    }
}