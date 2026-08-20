using SGTS.Data.Entities;

namespace SGTS.Data.Interfaces;

public interface IDepartamentosRepository
{
    Task<(IEnumerable<Departamento>, int, int)> GetAllDepartamentosAsync();

    Task<IEnumerable<Departamento>> GetAllNames();

    Task<Departamento?> GetByIdAsync(int id);

    Task<bool> AddAsync(Departamento entity);

    Task<bool> UpdateAsync(Departamento entity);

    Task<bool> DeleteAsync(Departamento entity);
}