using Microsoft.AspNetCore.Mvc;
using SGMF_backend.Models;
using SSS.Web.Models.Api;

namespace SGTS.Web.Controllers.Base;

[ApiController]
[Route("api/[controller]")]
public abstract class BaseController : ControllerBase
{

    //CUANDO SE EJECUTA EL DELETE, SE DEVUELVE UN 204 NO CONTENT
    protected IActionResult SuccessNoContent()
    {
        return NoContent();
    }

    // CUANDO SE EJECUTA EL POST, SE DEVUELVE UN 201 CREATED
    protected IActionResult SuccessCreate()
    {
        return Created();
    }

    // CUANDO SE EJECUTA UN GET O UN POST, SE DEVUELVE UN 200 OK CON EL OBJETO EN EL BODY
    protected IActionResult Success<T>(T? data = default, Pagination? pagination = default)
    {
        return Ok(ApiRes<T>.Success(data, pagination));
    }

    // CUANDO FALLA ALGO, SE DEVUELVE UN 400 BAD REQUEST POR DEFECTO CON EL MENSAJE DE ERROR EN EL BODY
    // EL EXCEPTION MIDDLEWARE CAPTURA LOS ERRORES Y DEVUELVE UN CODIGO DE ERROR CON EL MENSAJE DE ERROR EN EL BODY
    protected IActionResult Fail(string message, int statusCode = StatusCodes.Status400BadRequest)
    {
        return StatusCode(statusCode, ApiRes<object>.Fail(message));
    }

}
