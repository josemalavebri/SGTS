using SGTS.Shared.Const;
using SGTS.Shared.Enums;
using SGTS.Shared.Exceptions;
using SSS.Web.Models.Api;

namespace SGTS.Web.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private static async Task HandleExceptionAsync(
        HttpContext context,
        Exception exception)
    {
        context.Response.ContentType = "application/json";

        var (statusCode, message) = exception switch
        {
            IApplicationException ex =>
                (MapStatusCode(ex.Code), ex.Message),

            _ =>
                (
                    StatusCodes.Status500InternalServerError,
                    SystemMessages.ERROR_GENERICO
                )
        };

        context.Response.StatusCode = statusCode;

        await context.Response.WriteAsJsonAsync(
            ApiRes<object>.Fail(message));
    }

    private static int MapStatusCode(ErrorCode code)
    {
        return code switch
        {
            ErrorCode.Validation =>
                StatusCodes.Status400BadRequest,

            ErrorCode.BusinessRule =>
                StatusCodes.Status400BadRequest,

            ErrorCode.Forbidden =>
                StatusCodes.Status403Forbidden,

            ErrorCode.Unauthorized =>
                StatusCodes.Status401Unauthorized,

            ErrorCode.NotFound =>
                StatusCodes.Status404NotFound,

            ErrorCode.Conflict =>
                StatusCodes.Status409Conflict,

            ErrorCode.Persistence =>
                StatusCodes.Status500InternalServerError,

            ErrorCode.InternalError =>
                StatusCodes.Status500InternalServerError,

            _ =>
                StatusCodes.Status500InternalServerError
        };
    }
}