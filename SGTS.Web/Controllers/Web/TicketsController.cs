using Microsoft.AspNetCore.Mvc;

namespace SGTS.Web.Controllers.Web;

public class TicketsController : Controller
{

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult CrearTickets()
    {
        return View();
    }
    public IActionResult TicketDetail(int id)
    {
        ViewBag.IdTicket = id;
        return View();
    }
}