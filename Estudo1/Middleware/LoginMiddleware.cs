using Estudo1.Helpers;

namespace Estudo1.Middleware;

public class LoginMiddleware(RequestDelegate next)
{
    private readonly List<string> _validTokens =
    [
        "12345",
        "12",
        "18"
    ];
    private readonly RequestDelegate _next = next;

    public async Task InvokeAsync(HttpContext context)
    {
        var token = context.Request.Headers.Authorization;

        if (!_validTokens.Contains(token.ToString()))
        {
            // throw new GenericApiError("Token invalid", 404);
        }

        context.Request.Headers.Append("user_name", "jose");

        await _next(context); // próxima coisa'
 
        // depois, na volta
    }
}


    public static class LoginMiddlewareExtensions
    {
        public static IApplicationBuilder UseLoginMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LoginMiddleware>();
        }
    }