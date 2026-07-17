using Microsoft.AspNetCore.Mvc;

namespace SGTS.Web.Controllers.Web;

public class DepartamentoController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}