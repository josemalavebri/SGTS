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
}