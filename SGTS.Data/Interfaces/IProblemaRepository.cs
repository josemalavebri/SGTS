using SGTS.Data.Entities;
using SGTS.Models.DTOs;

namespace SGTS.Data.Interfaces;

public interface IProblemaRepository
{
    Task<PagedResult<Ticket>> DataTableQueryService(DataTableRequest request);

    Task<Ticket?> GetByIdAsync(int id);

    Task AddAsync(Ticket entity);

    Task UpdateAsync(Ticket entity);

    Task DeleteAsync(int id);
}