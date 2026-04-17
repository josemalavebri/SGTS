using SGTS.Data.Entities;
using SGTS.Models.DTOs;

namespace SGTS.Data.Interfaces;

public interface IUsuarioRepository
{
    Task<PagedResult<Usuario>> GetPagedAsync(DataTableRequest request);

    Task<Usuario?> GetByIdAsync(int id);

    Task<bool> EmailExistsAsync(string email);

    Task<IEnumerable<Usuario>> GetByNameAsync(string nombre);

    Task AddAsync(Usuario usuario);

    Task UpdateAsync(Usuario usuario);

    Task DeleteAsync(Usuario usuario);
}