using Microsoft.AspNetCore.Mvc;

namespace SGTS.Web.Controllers.Web;

public class TicketsController : Controller
{

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult NuevoTicket()
    {
        return View();
    }

    public IActionResult DetalleTicket(int id)
    {
        ViewBag.IdTicket = id;
        return View();
    }
}