using Microsoft.EntityFrameworkCore;
using SGTS.Data.Context;
using SGTS.Data.Entities;
using SGTS.Data.Interfaces;

namespace SGTS.Data.Repositories;

public class PrioridadRepository : IPrioridadRepository
{
    private readonly AppDbContext _appDbContext;

    public PrioridadRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<IEnumerable<Prioridad>> GetAllPrioridadesAsync()
    {
        return await _appDbContext.Prioridades
            .AsNoTracking()
            .ToListAsync();
    }
}