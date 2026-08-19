using SGTS.Data.Entities;
using SGTS.Models.DTOs;

public interface ITicketService
{
    Task<Ticket> CreateTicketAsync(TicketDto ticketDto);
}