using SGTS.Business.Exceptions;
using SGTS.Data.Exceptions;
using SGTS.Shared.Const;
using SGTS.Web.Models.Api;

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

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";

        var (statusCode, message) = exception switch
        {
            BusinessException ex => (MapStatusCode(ex.Code), ex.Message),

            PersistenceException => (StatusCodes.Status500InternalServerError, SystemMessages.Sistema.ERROR_INTERNO),

            _ => (StatusCodes.Status500InternalServerError, SystemMessages.Sistema.ERROR_GENERICO)
        };

        context.Response.StatusCode = statusCode;
        await context.Response.WriteAsJsonAsync(ApiRes<object>.Fail(message));
    }
    private int MapStatusCode(string code) => code switch
    {
        ErrorCodes.VALIDATION => StatusCodes.Status400BadRequest,
        ErrorCodes.BUSINESS_RULE => StatusCodes.Status400BadRequest,
        ErrorCodes.FORBIDDEN => StatusCodes.Status403Forbidden,
        ErrorCodes.NOT_FOUND => StatusCodes.Status404NotFound,
        ErrorCodes.CONFLICT => StatusCodes.Status409Conflict,
        _ => StatusCodes.Status500InternalServerError
    };
}