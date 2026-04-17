using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SGTS.Web.Models;

namespace SGTS.Web.Controllers.Web;

public class HomeController : Controller
{
    public HomeController()
    {
    }
    public IActionResult Index()
    {
        // Datos simulados de estados
        var estados = new List<EstadoDTO>
        {
            new EstadoDTO { Nombre = "abierto", Cantidad = 5 },
            new EstadoDTO { Nombre = "en-progreso", Cantidad = 3 },
            new EstadoDTO { Nombre = "resuelto", Cantidad = 8 },
            new EstadoDTO { Nombre = "cerrado", Cantidad = 2 }
        };

        // Datos simulados de prioridades
        var prioridades = new List<PrioridadDTO>
        {
            new PrioridadDTO { Nombre = "baja", Cantidad = 4 },
            new PrioridadDTO { Nombre = "media", Cantidad = 7 },
            new PrioridadDTO { Nombre = "alta", Cantidad = 7 }
        };

        // Construir ViewModel
        var model = new DashboardViewModel
        {
            Estados = estados,
            Prioridades = prioridades
        };

        return View(model);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}


public class EstadoDTO
{
    public string Nombre { get; set; }
    public int Cantidad { get; set; }
}

public class PrioridadDTO
{
    public string Nombre { get; set; }
    public int Cantidad { get; set; }
}