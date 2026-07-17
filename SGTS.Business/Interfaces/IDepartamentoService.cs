using SGTS.Models.DTOs;

namespace SGTS.Business.Interfaces;

public interface IDepartamentoService
{
    Task<PagedResult<DepartamentoDTO>> GetAllDepartamentosAsync(DataTableRequestDTO request);
    Task<DepartamentoDTO> GetDepartamentoByIdAsync(int id);
    Task<bool> CreateDepartamentoAsync(DepartamentoDTO departamento);
    Task<bool> UpdateDepartamentoAsync(DepartamentoDTO departamento);
    Task<bool> DeleteDepartamentoAsync(int id);
}
