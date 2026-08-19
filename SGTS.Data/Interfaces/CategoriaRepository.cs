using SGTS.Data.Entities;

namespace SGTS.Data.Interfaces;

public interface ICategoriaRepository
{
    Task<List<Categoria>> GetAllCategoriasAsync();
}