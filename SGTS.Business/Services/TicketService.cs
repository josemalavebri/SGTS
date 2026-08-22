using SGTS.Business.Const;
using SGTS.Business.Exceptions;
using SGTS.Data.Entities;
using SGTS.Data.Interfaces;
using SGTS.Models.Query.DTOs;
using SGTS.Models.Ticket.Dtos;
using SGTS.Shared.Enums;

namespace SGTS.Business.Services;

public class TicketService : ITicketService
{
    private readonly ITicketRepository _ticketRepository;

    public TicketService(ITicketRepository ticketRepository)
    {
        _ticketRepository = ticketRepository;
    }

    public async Task<PagedResult<TicketDtoResponse>> GetAllTicketsAsync(
    TicketQueryRequestDTO request)
    {
        return await _ticketRepository.GetAllAsync(request);
    }

    public async Task<TicketDetailDto> GetTicketDetailAsync(int idTicket)
    {
        var ticket = await _ticketRepository
            .GetTicketDetailAsync(idTicket);

        if (ticket is null)
        {
            throw new BusinessException(
                ErrorCode.NotFound,
                TicketMessages.NOT_FOUND);
        }

        return ticket;
    }

    public async Task<Ticket> CreateTicketAsync(TicketDto ticketDto)
    {
        var ticket = new Ticket
        {
            IdUsuario = ticketDto.IdUsuario,
            IdCategoria = ticketDto.IdCategoria,
            IdPrioridad = ticketDto.IdPrioridad,
            IdEstado = 1,
            Titulo = ticketDto.Titulo,
            Descripcion = ticketDto.Descripcion,
            FechaCreacion = DateTime.Now
        };

        return await _ticketRepository.CreateAsync(ticket);
    }



}