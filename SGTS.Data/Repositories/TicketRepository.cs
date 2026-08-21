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

    public async Task<TicketDetailDto?> GetTicketDetailAsync(int idTicket)
    {
        return await _context.Tickets
            .AsNoTracking()
            .Where(t => t.IdTicket == idTicket)
            .Select(t => new TicketDetailDto
            {
                // DATOS DEL TICKET
                IdTicket = t.IdTicket,
                Titulo = t.Titulo,
                Descripcion = t.Descripcion,
                FechaCreacion = t.FechaCreacion,
                FechaCierre = t.FechaCierre,

                // INFORMACIÓN DEL TICKET
                Categoria = t.Categoria.Nombre,
                Prioridad = t.Prioridad.Nombre,
                Estado = t.Estado.Nombre,

                // ÚLTIMA ACTUALIZACIÓN
                UltimaActualizacion = t.Actividades
                    .OrderByDescending(a => a.Fecha)
                    .Select(a => (DateTime?)a.Fecha)
                    .FirstOrDefault(),

                // SOLICITANTE
                Solicitante = new UsuarioTicketDto
                {
                    IdUsuario = t.Usuario.IdUsuario,
                    Nombre = t.Usuario.Nombre,
                    Apellido = t.Usuario.Apellido,
                },

                // TÉCNICO ACTUAL
                TecnicoAsignado = t.Asignaciones
                    .Where(a => a.FechaDesasignacion == null)
                    .Select(a => new UsuarioTicketDto
                    {
                        IdUsuario = a.Tecnico.IdUsuario,
                        Nombre = a.Tecnico.Nombre,
                        Apellido = a.Tecnico.Apellido,
                    })
                    .FirstOrDefault(),

                // ACTIVIDADES
                Actividades = t.Actividades
                    .OrderBy(a => a.Fecha)
                    .Select(a => new ActividadTicketDto
                    {
                        Tipo = a.TipoActividad.Nombre,

                        Fecha = a.Fecha
                    })
                    .ToList()
            })
            .FirstOrDefaultAsync();
    }

    public async Task<Ticket> CreateAsync(Ticket ticket)
    {
        await _context.Tickets.AddAsync(ticket);
        await _context.SaveChangesAsync();

        return ticket;
    }
}