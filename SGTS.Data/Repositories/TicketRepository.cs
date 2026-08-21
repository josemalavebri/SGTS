using Microsoft.EntityFrameworkCore;
using SGTS.Data.Context;
using SGTS.Data.Entities;
using SGTS.Data.Interfaces;
using SGTS.Models.Query.DTOs;
using SGTS.Models.Query.Enums;
using SGTS.Models.Ticket.Dtos;
using SGTS.Models.Ticket.Enums;

namespace SGTS.Data.Repositories;

public class TicketRepository : ITicketRepository
{
    private readonly AppDbContext _context;

    public TicketRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<PagedResult<Ticket>> GetAllAsync(
        TicketQueryRequestDTO request)
    {
        var pagination = request.Pagination ?? new PaginationRequestDTO
        {
            Start = 0,
            Length = 5
        };

        IQueryable<Ticket> query = _context.Tickets
            .AsNoTracking()
            .Include(t => t.Categoria)
            .Include(t => t.Prioridad)
            .Include(t => t.Estado);

        var totalRecords = await query.CountAsync();

        query = ApplySearch(
            query,
            request.Filters?.Busqueda);

        query = ApplyFilters(
            query,
            request.Filters);

        var totalRecordsFiltered = await query.CountAsync();

        query = ApplyOrdering(
            query,
            request.Order);

        var items = await query
            .Skip(pagination.Start)
            .Take(pagination.Length)
            .ToListAsync();

        var pageNumber =
            (pagination.Start / pagination.Length) + 1;

        return new PagedResult<Ticket>
        {
            Items = items,
            PageNumber = pageNumber,
            PageSize = pagination.Length,
            TotalRecords = totalRecords,
            TotalRecordsFiltered = totalRecordsFiltered
        };
    }

    private IQueryable<Ticket> ApplySearch(
        IQueryable<Ticket> query,
        string? busqueda)
    {
        if (string.IsNullOrWhiteSpace(busqueda))
            return query;

        busqueda = busqueda.Trim();

        return query.Where(t =>
            t.Titulo.Contains(busqueda) ||
            t.Descripcion.Contains(busqueda));
    }

    private IQueryable<Ticket> ApplyFilters(
        IQueryable<Ticket> query,
        TicketFilterDto? filters)
    {
        if (filters == null)
            return query;

        if (filters.IdEstado.HasValue)
        {
            query = query.Where(t =>
                t.IdEstado == filters.IdEstado.Value);
        }

        if (filters.IdPrioridad.HasValue)
        {
            query = query.Where(t =>
                t.IdPrioridad == filters.IdPrioridad.Value);
        }

        if (filters.IdCategoria.HasValue)
        {
            query = query.Where(t =>
                t.IdCategoria == filters.IdCategoria.Value);
        }

        return query;
    }

    private IQueryable<Ticket> ApplyOrdering(
        IQueryable<Ticket> query,
        OrderRequestDTO<TicketOrderColumn>? order)
    {
        if (order?.Column == null)
        {
            return query.OrderByDescending(
                t => t.FechaCreacion);
        }

        var ascending =
            order.Direction == OrderDirection.Asc;

        return order.Column switch
        {
            TicketOrderColumn.Titulo =>
                ascending
                    ? query.OrderBy(t => t.Titulo)
                    : query.OrderByDescending(t => t.Titulo),

            TicketOrderColumn.FechaCreacion =>
                ascending
                    ? query.OrderBy(t => t.FechaCreacion)
                    : query.OrderByDescending(t => t.FechaCreacion),

            TicketOrderColumn.Prioridad =>
                ascending
                    ? query.OrderBy(t => t.IdPrioridad)
                    : query.OrderByDescending(t => t.IdPrioridad),

            _ =>
                query.OrderByDescending(
                    t => t.FechaCreacion)
        };
    }


    public async Task<Ticket?> GetByIdAsync(int id)
    {
        return await _context.Tickets
            .Include(t => t.Usuario)
            .Include(t => t.Actividades)
            .Include(t => t.Categoria)
            .Include(t => t.Prioridad)
            .Include(t => t.Estado)
            .Include(t => t.Comentarios)
            .Include(t => t.Adjuntos)
            .FirstOrDefaultAsync(t => t.IdTicket == id);
    }


    public async Task<Ticket> CreateAsync(Ticket ticket)
    {
        await _context.Tickets.AddAsync(ticket);
        await _context.SaveChangesAsync();

        return ticket;
    }
}