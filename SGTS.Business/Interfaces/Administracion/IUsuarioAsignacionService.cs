using SGTS.Models.DTOs.Administracion;
using SGTS.Models.DTOs;


namespace SGTS.Business.Interfaces;

public interface IUsuarioAsignacionService
{
    Task<PagedResult<UsuarioAsignacionDTO>> GetAllAsync(DataTableRequestDTO dto);
    Task<UsuarioAsignacionDTO?> GetByIdAsync(int id);
    Task<bool> CreateAsync(UsuarioAsignacionDTO dto);
    Task<bool> UpdateAsync(UsuarioAsignacionDTO dto);
    Task<bool> DeleteAsync(int id);
    Task<object> GetAllAsync();



}
