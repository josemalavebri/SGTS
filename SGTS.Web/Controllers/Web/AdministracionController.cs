using Microsoft.AspNetCore.Mvc;

namespace SGTS.Web.Controllers.Web;

public class AdministracionController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}