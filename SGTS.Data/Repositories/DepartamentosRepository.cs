
using Microsoft.EntityFrameworkCore;
using SGTS.Data.Context;
using SGTS.Data.Entities;
using SGTS.Data.Interfaces;

namespace SGTS.Data.Repositories;

public class DepartamentosRepository : IDepartamentosRepository
{
    private readonly AppDbContext context;

    public DepartamentosRepository(AppDbContext context)
    {
        this.context = context;
    }
    public async Task<(IEnumerable<Departamento>, int, int)> GetAllDepartamentosAsync()
    {

        return (null, 0, 0);
    }

    public async Task<IEnumerable<Departamento>> GetAllNames()
    {
        return await context.Departamentos.AsNoTracking().Select(d => new Departamento
        {
            IdDepartamento = d.IdDepartamento,
            Nombre = d.Nombre
        }).ToListAsync();
    }

    public async Task<Departamento?> GetByIdAsync(int id)
    {
        return await context.Departamentos.AsNoTracking()
            .FirstOrDefaultAsync(d => d.IdDepartamento == id);
    }

    public async Task<bool> AddAsync(Departamento entity)
    {
        await context.AddAsync(entity);
        return await context.SaveChangesAsync() > 0;
    }

    public async Task<bool> UpdateAsync(Departamento entity)
    {
        context.Entry(entity).State = EntityState.Modified;
        return await context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteAsync(Departamento entity)
    {
        context.Departamentos.Remove(entity);
        return await context.SaveChangesAsync() > 0;
    }
}