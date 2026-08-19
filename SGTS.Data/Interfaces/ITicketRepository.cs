using SGTS.Data.Entities;

namespace SGTS.Data.Interfaces;

public interface ITicketRepository
{
    Task<List<Ticket>> GetAllTicketsAsync();

    Task<Ticket> CreateTicketAsync(Ticket ticket);
}