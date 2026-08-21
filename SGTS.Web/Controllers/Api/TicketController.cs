using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using SGMF_backend.Models;
using SGTS.Models.Ticket.Dtos;
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
    public async Task<IActionResult> GetAllTickets(
    [FromQuery] TicketQueryRequestDTO request)
    {
        Console.WriteLine(
            "---------- REQUEST: " +
            JsonSerializer.Serialize(request)
        );

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
    public async Task<IActionResult> CreateTicket(TicketDto ticketDto)
    {
        await _ticketService.CreateTicketAsync(ticketDto);

        return SuccessCreate();
    }


}