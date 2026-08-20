using SGTS.Data.Entities;
using SGTS.Models.Query.DTOs;
using SGTS.Models.Ticket.Dtos;

namespace SGTS.Data.Interfaces;

public interface ITicketRepository
{
    Task<PagedResult<Ticket>> GetAllTicketsAsync(TicketQueryRequestDTO request);


    Task<Ticket> CreateTicketAsync(Ticket ticket);
}