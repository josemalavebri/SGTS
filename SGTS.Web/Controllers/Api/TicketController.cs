using Microsoft.AspNetCore.Mvc;
using SGTS.Models.Ticket.Dtos;
using SGTS.Web.Controllers.Base;
using SGTS.Web.Models.Api;

namespace SGTS.Web.Controllers.Api;

public class TicketController : BaseController
{
    private readonly ITicketService _ticketService;

    public TicketController(ITicketService ticketService)
    {
        _ticketService = ticketService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllTickets(
    [FromQuery] TicketQueryRequestDTO request)
    {

        var tickets = await _ticketService
            .GetAllTicketsAsync(request);

        var pagination = new Pagination
        {
            PageNumber = tickets.PageNumber,
            PageSize = tickets.PageSize,
            TotalRecords = tickets.TotalRecords,
            TotalRecordsFiltered = tickets.TotalRecordsFiltered
        };

        return Success(tickets.Items, pagination);
    }

    [HttpGet("{idTicket:int}")]
    public async Task<IActionResult> GetTicketDetail(int idTicket)
    {
        var ticket = await _ticketService
            .GetTicketDetailAsync(idTicket);

        if (ticket is null)
        {
            return NotFound();
        }

        return Success(ticket);
    }

    [HttpPost]
    public async Task<IActionResult> CreateTicket([FromBody] TicketDto ticketDto)
    {
        await _ticketService.CreateTicketAsync(ticketDto);

        return SuccessCreate();
    }


}