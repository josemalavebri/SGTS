using Microsoft.AspNetCore.Mvc;

namespace SGTS.Web.Controllers.Web;

public class AdministracionController : Controller
{
    public IActionResult Departamentos()
    {
        return View();
    }

    public IActionResult Usuarios()
    {
        return View();
    }

    public IActionResult UsuarioAsignacion()
    {
        return View();
    }
}