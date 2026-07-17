
using Microsoft.EntityFrameworkCore;
using SGTS.Data.Context;
using SGTS.Data.Entities;
using SGTS.Data.Interfaces;
using SGTS.Data.Services;
using SGTS.Models.DTOs;

namespace SGTS.Business.Interfaces;

public class DepartamentosReposity : IDepartamentosRepository
{
    private readonly AppDbContext context;
    private readonly DataTableQueryService dataTQService;

    public DepartamentosReposity(AppDbContext context, DataTableQueryService dataTableQueryService)
    {
        this.context = context;
        this.dataTQService = dataTableQueryService;
    }

    public async Task<(IEnumerable<Departamento>, int, int)> GetAllDepartamentosAsync(DataTableRequestDTO request)
    {

        return await dataTQService.QueryAsync(context.Departamentos.AsNoTracking(), request);
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