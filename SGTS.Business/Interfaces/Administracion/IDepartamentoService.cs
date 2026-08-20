using SGTS.Models.DTOs;
using SGTS.Models.Query.DTOs;

namespace SGTS.Business.Interfaces;

public interface IDepartamentoService
{
    Task<PagedResult<DepartamentoDTO>> GetAllDepartamentosAsync();
    Task<DepartamentoDTO> GetDepartamentoByIdAsync(int id);
    Task<IEnumerable<DepartamentoDTO>> GetAllNames();
    Task<bool> CreateDepartamentoAsync(DepartamentoDTO departamento);
    Task<bool> UpdateDepartamentoAsync(DepartamentoDTO departamento);
    Task<bool> DeleteDepartamentoAsync(int id);
}
