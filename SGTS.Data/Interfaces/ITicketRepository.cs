using SGTS.Data.Entities;
using SGTS.Models.Query.DTOs;
using SGTS.Models.Ticket.Dtos;

namespace SGTS.Data.Interfaces;

public interface ITicketRepository
{
    Task<PagedResult<Ticket>> GetAllAsync(TicketQueryRequestDTO request);

    Task<Ticket?> GetByIdAsync(int id);

    Task<Ticket> CreateAsync(Ticket ticket);
    
}