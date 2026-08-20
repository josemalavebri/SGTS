using SGTS.Data.Entities;
using SGTS.Models.DTOs;

namespace SGTS.Data.Interfaces;

public interface ITicketRepository
{
    Task<List<Ticket>> GetAllTicketsAsync();

    Task<List<Ticket>> GetFilteredTicketsAsync(TicketFilterDto filter);

    Task<Ticket> CreateTicketAsync(Ticket ticket);
}