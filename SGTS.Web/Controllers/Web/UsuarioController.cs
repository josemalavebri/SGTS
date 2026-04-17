using Microsoft.AspNetCore.Mvc;

namespace SGTS.Web.Controllers.Web;

public class UsuarioController : Controller
{

    public IActionResult Index()
    {
        return View();
    }

}