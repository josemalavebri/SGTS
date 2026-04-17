using Microsoft.AspNetCore.Mvc;
using SGMF_backend.Models;
using SGTS.Web.Models.Api;

namespace SGTS.Web.Controllers.Base;

[ApiController]
[Route("api/[controller]")]
public abstract class BaseController : ControllerBase
{

    protected IActionResult SuccessNoContent()
    {
        return NoContent();
    }

    protected IActionResult Success<T>(T? data = default, Pagination? pagination = default)
    {
        return Ok(ApiRes<T>.Success(data, pagination));
    }

    protected IActionResult Fail(string message, int statusCode = StatusCodes.Status400BadRequest)
    {
        return StatusCode(statusCode, ApiRes<object>.Fail(message));
    }
}
