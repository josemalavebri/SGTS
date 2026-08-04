using SGTS.Data.Entities;
using SGTS.Models.DTOs;

namespace SGTS.Data.Interfaces;

public interface IDepartamentosRepository
{
    Task<(IEnumerable<Departamento>, int, int)> GetAllDepartamentosAsync(DataTableRequestDTO request);

    Task<IEnumerable<Departamento>> GetAllNames();

    Task<Departamento?> GetByIdAsync(int id);

    Task<bool> AddAsync(Departamento entity);

    Task<bool> UpdateAsync(Departamento entity);

    Task<bool> DeleteAsync(Departamento entity);
}