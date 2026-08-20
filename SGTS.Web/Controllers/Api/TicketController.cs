using Microsoft.AspNetCore.Mvc;
using SGTS.Models.DTOs;
using SGTS.Web.Controllers.Base;

namespace SGTS.Web.Controllers.Api;

public class TicketController : BaseController
{
    private readonly ITicketService _ticketService;

    public TicketController(ITicketService ticketService)
    {
        _ticketService = ticketService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllTickets()
    {
        var tickets = await _ticketService.GetAllTicketsAsync();

        return Ok(tickets);
    }


    [HttpGet("filtrar")]
    public async Task<IActionResult> GetFilteredTickets(
        [FromQuery] TicketFilterDto filter)
    {
        var tickets = await _ticketService
            .GetFilteredTicketsAsync(filter);

        return Ok(tickets);
    }
    [HttpPost]
    public async Task<IActionResult> CreateTicket(TicketDto ticketDto)
    {
        await _ticketService.CreateTicketAsync(ticketDto);

        return SuccessCreate();
    }


}