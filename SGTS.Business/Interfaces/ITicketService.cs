using SGTS.Data.Entities;
using SGTS.Models.Query.DTOs;
using SGTS.Models.Ticket.Dtos;

public interface ITicketService
{
    Task<PagedResult<TicketDtoResponse>> GetAllTicketsAsync(TicketQueryRequestDTO request);

    Task<TicketDetailDto?> GetTicketDetailAsync(int idTicket);

    Task<Ticket> CreateTicketAsync(TicketDto ticketDto);
}