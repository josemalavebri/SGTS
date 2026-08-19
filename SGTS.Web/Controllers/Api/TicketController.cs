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

    [HttpPost]
    public async Task<IActionResult> CreateTicket(TicketDto ticketDto)
    {
        await _ticketService.CreateTicketAsync(ticketDto);

        return SuccessCreate();
    }
}