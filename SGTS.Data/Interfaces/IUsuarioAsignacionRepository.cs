using SGTS.Data.Entities;

namespace SGTS.Data.Interfaces;

public interface IUsuarioAsignacionRepository
{
    Task<(IEnumerable<UsuarioAsignacion>, int, int)> GetAllAsync();
    Task<UsuarioAsignacion?> GetByIdAsync(int id);
    Task<bool> AddAsync(UsuarioAsignacion entity);
    Task<bool> UpdateAsync(UsuarioAsignacion entity);
    Task<bool> DeleteAsync(UsuarioAsignacion entity);
}