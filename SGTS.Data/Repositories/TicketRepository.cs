using SGTS.Data.Context;
using SGTS.Data.Entities;
using SGTS.Data.Interfaces;

namespace SGTS.Data.Repositories;

public class TicketRepository : ITicketRepository
{
    private readonly AppDbContext _context;

    public TicketRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Ticket> CreateTicketAsync(Ticket ticket)
    {
        await _context.Tickets.AddAsync(ticket);
        await _context.SaveChangesAsync();

        return ticket;
    }
}