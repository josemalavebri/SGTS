using SGTS.Business.Interfaces;
using SGTS.Data.Interfaces;
using SGTS.Models.DTOs;

namespace SGTS.Business.Services;

public class CategoriaService : ICategoriaService
{
    private readonly ICategoriaRepository _categoriaRepository;

    public CategoriaService(ICategoriaRepository categoriaRepository)
    {
        _categoriaRepository = categoriaRepository;
    }

    public async Task<List<CategoriaDTO>> GetAllCategoriasAsync()
    {
        var categorias = await _categoriaRepository.GetAllCategoriasAsync();

        return categorias.Select(c => new CategoriaDTO
        {
            IdCategoria = c.IdCategoria,
            Nombre = c.Nombre
        }).ToList();
    }
}