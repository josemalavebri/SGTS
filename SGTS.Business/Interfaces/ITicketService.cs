using SGTS.Data.Entities;
using SGTS.Models.DTOs;

public interface ITicketService
{
    Task<List<TicketDtoResponse>> GetAllTicketsAsync();

    Task<Ticket> CreateTicketAsync(TicketDto ticketDto);
}