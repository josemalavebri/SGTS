using Microsoft.EntityFrameworkCore;
using SGTS.Data.Context;
using SGTS.Data.Entities;
using SGTS.Data.Interfaces;
using SGTS.Models.DTOs;

namespace SGTS.Data.Repositories;

public class TicketRepository : ITicketRepository
{
    private readonly AppDbContext _context;

    public TicketRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Ticket>> GetAllTicketsAsync()
    {
        return await _context.Tickets
            .AsNoTracking()
            .Include(t => t.Categoria)
            .Include(t => t.Prioridad)
            .Include(t => t.Estado)
            .Include(t => t.TecnicoAsignado)
            .ToListAsync();
    }

    public async Task<List<Ticket>> GetFilteredTicketsAsync(TicketFilterDto filter)
    {
        var query = _context.Tickets
            .AsNoTracking()
            .Include(t => t.Categoria)
            .Include(t => t.Prioridad)
            .Include(t => t.Estado)
            .Include(t => t.TecnicoAsignado)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(filter.Busqueda))
        {   
            var busqueda = filter.Busqueda.Trim();

            query = query.Where(t =>
                t.Titulo.Contains(busqueda) ||
                t.Descripcion.Contains(busqueda));
        }

        if (filter.IdEstado.HasValue)
        {
            query = query.Where(t =>
                t.IdEstado == filter.IdEstado.Value);
        }

        if (filter.IdPrioridad.HasValue)
        {
            query = query.Where(t =>
                t.IdPrioridad == filter.IdPrioridad.Value);
        }

        if (filter.IdCategoria.HasValue)
        {
            query = query.Where(t =>
                t.IdCategoria == filter.IdCategoria.Value);
        }

        return await query.ToListAsync();
    }

    public async Task<Ticket> CreateTicketAsync(Ticket ticket)
    {
        await _context.Tickets.AddAsync(ticket);
        await _context.SaveChangesAsync();

        return ticket;
    }
}