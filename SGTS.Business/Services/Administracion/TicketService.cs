using SGTS.Data.Entities;
using SGTS.Data.Interfaces;
using SGTS.Models.DTOs;

namespace SGTS.Business.Services.Administracion;

public class TicketService : ITicketService
{
    private readonly ITicketRepository _ticketRepository;

    public TicketService(ITicketRepository ticketRepository)
    {
        _ticketRepository = ticketRepository;
    }

    public async Task<List<TicketDtoResponse>> GetAllTicketsAsync()
    {
        var tickets = await _ticketRepository.GetAllTicketsAsync();

        return MapToResponse(tickets);
    }

    public async Task<List<TicketDtoResponse>> GetFilteredTicketsAsync(
        TicketFilterDto filter)
    {
        var tickets = await _ticketRepository
            .GetFilteredTicketsAsync(filter);

        return MapToResponse(tickets);
    }
    public async Task<Ticket> CreateTicketAsync(TicketDto ticketDto)
    {
        var ticket = new Ticket
        {
            IdUsuario = 1,
            IdCategoria = ticketDto.IdCategoria,
            IdPrioridad = ticketDto.IdPrioridad,
            IdEstado = 1,
            Titulo = ticketDto.Titulo,
            Descripcion = ticketDto.Descripcion,
            FechaCreacion = DateTime.Now
        };

        return await _ticketRepository.CreateTicketAsync(ticket);
    }


    private static List<TicketDtoResponse> MapToResponse(
       List<Ticket> tickets)
    {
        return tickets.Select(ticket => new TicketDtoResponse
        {
            IdTicket = ticket.IdTicket,
            Titulo = ticket.Titulo,
            Descripcion = ticket.Descripcion,
            Categoria = ticket.Categoria.Nombre,
            Prioridad = ticket.Prioridad.Nombre,
            Estado = ticket.Estado.Nombre,
            TecnicoAsignado = ticket.TecnicoAsignado != null
                ? ticket.TecnicoAsignado.Nombre
                : null,
            FechaCreacion = ticket.FechaCreacion,
            FechaActualizacion = ticket.FechaActualizacion
        }).ToList();
    }
}