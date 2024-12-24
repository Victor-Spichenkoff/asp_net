namespace Estudo1.Middleware;

public class TesteMiddleware(RequestDelegate next)
{
    private readonly RequestDelegate _next = next;

    public async Task InvokeAsync(HttpContext context)
    {
        // antes de chamar o próximo
        var userName = context.Request.Query["nhe"];
        Console.WriteLine($"User: {userName}");
        context.Response.Headers.Append("ID_Middleware", Guid.NewGuid().ToString());
        // context.Response.Headers.Append("query", userName[0]?.ToString());
        
        await _next(context); // próxima coisa'

        // depois, na volta
    }
}

// adiciona ela ao pipeline
public static class MiddlewareExtensions// o nome não importa
{
    // precisa do this; o nome do param também é irrelevante
    public static IApplicationBuilder UseMyMiddleware(this IApplicationBuilder currentPipeline)
    {
        // currentPipeline == vem implicitamente e contem o estado atual do pipe
        return currentPipeline.UseMiddleware<TesteMiddleware>();
    }
}