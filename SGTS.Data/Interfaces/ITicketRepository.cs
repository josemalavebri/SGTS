using SGTS.Data.Entities;
using SGTS.Models.Query.DTOs;
using SGTS.Models.Ticket.Dtos;

namespace SGTS.Data.Interfaces;

public interface ITicketRepository
{
    Task<PagedResult<TicketDtoResponse>> GetAllAsync(TicketQueryRequestDTO request);
    Task<TicketDetailDto?> GetTicketDetailAsync(int idTicket);
    Task<Ticket> CreateAsync(Ticket ticket);

}