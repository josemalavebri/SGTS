using SGTS.Data.Entities;
using SGTS.Models.DTOs;

namespace SGTS.Data.Interfaces;

public interface IUsuarioAsignacionRepository
{
    Task<(IEnumerable<UsuarioAsignacion>, int, int)> GetAllAsync(DataTableRequestDTO dto);
    Task<UsuarioAsignacion?> GetByIdAsync(int id);
    Task<bool> AddAsync(UsuarioAsignacion entity);
    Task<bool> UpdateAsync(UsuarioAsignacion entity);
    Task<bool> DeleteAsync(UsuarioAsignacion entity);
}