using SGTS.Data.Entities;

namespace SGTS.Data.Interfaces;

public interface ITicketRepository
{
    Task<Ticket> CreateTicketAsync(Ticket ticket);
}