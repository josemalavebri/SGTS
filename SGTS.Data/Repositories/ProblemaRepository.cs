using Microsoft.EntityFrameworkCore;
using SGTS.Data.Const;
using SGTS.Data.Context;
using SGTS.Data.Entities;
using SGTS.Data.Exceptions;
using SGTS.Data.Interfaces;
using SGTS.Data.Services;
using SGTS.Models.DTOs;

namespace SGTS.Data.Repositories;

public class ProblemaRepository(AppDbContext context, DataTableQueryService queryService) : IProblemaRepository
{
    private readonly AppDbContext _context = context;
    private readonly DataTableQueryService _queryService = queryService;

    public async Task<PagedResult<Ticket>> DataTableQueryService(DataTableRequest request)
    {
        var query = _context.Problemas
            .Include(p => p.Usuario)
            .Include(p => p.Prioridad)
            .Where(p => p.Activo);

        var (items, totalRecords, totalRecordsFiltered) = await _queryService.QueryAsync(
            query,
            request,
            search => x =>
                x.Descripcion.Contains(search) ||
                x.Usuario.Nombre.Contains(search)
        );

        return new PagedResult<Ticket>
        {
            Items = items.ToList(),
            TotalRecords = totalRecords,
            TotalRecordsFiltered = totalRecordsFiltered
        };
    }

    public async Task<Ticket?> GetByIdAsync(int id)
    {
        try
        {
            return await _context.Problemas
                .Include(p => p.Usuario)
                .Include(p => p.Prioridad)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
        catch (Exception ex)
        {
            throw new PersistenceException(DataMessages.ERROR_OBTENER, ex);
        }
    }

    public async Task AddAsync(Ticket entity)
    {
        _context.Problemas.Add(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Ticket entity)
    {
        var existing = await _context.Problemas.FindAsync(entity.Id);

        if (existing == null)
            throw new PersistenceException($"No se encontró el problema con id {entity.Id}");

        _context.Entry(existing).CurrentValues.SetValues(entity);

        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _context.Problemas.FindAsync(id);

        if (entity == null)
            throw new PersistenceException($"No se encontró el problema con id {id}");

        _context.Problemas.Remove(entity);

        await _context.SaveChangesAsync();
    }
}