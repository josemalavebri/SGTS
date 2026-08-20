using SGTS.Data.Entities;
using SGTS.Models.DTOs;

public interface ITicketService
{
    Task<List<TicketDtoResponse>> GetAllTicketsAsync();

    Task<List<TicketDtoResponse>> GetFilteredTicketsAsync(TicketFilterDto filter);

    Task<Ticket> CreateTicketAsync(TicketDto ticketDto);
}