using SGTS.Models.DTOs;

namespace SGTS.Business.Interfaces;

public interface ICategoriaService
{
    Task<List<CategoriaDTO>> GetAllCategoriasAsync();
}