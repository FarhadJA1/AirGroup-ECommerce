using A.Domain.Exceptions;
using System.Net;
using System.Text.Json;

namespace D.App.Infrastructure.Middlewares;
public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;
    public ExceptionHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (InvalidClientOperationException ex)
        {
            var messages = new List<string>() { ex.Message };
            await WriteError(context, HttpStatusCode.BadRequest, messages);
        }
        catch (Exception ex)
        {
            var messages = new List<string>() { ex.Message };
            await WriteError(context, HttpStatusCode.InternalServerError, messages);
        }
    }

    private static async Task WriteError(HttpContext context, HttpStatusCode statusCode, List<string> messages)
    {
        context.Response.Clear();
        context.Response.StatusCode = (int)statusCode;
        context.Response.ContentType = "application/json; charset=utf-8";

        var options = new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
        var json = JsonSerializer.Serialize(new HttpErrorResponse(messages), options);
        await context.Response.WriteAsync(json);
    }
}
