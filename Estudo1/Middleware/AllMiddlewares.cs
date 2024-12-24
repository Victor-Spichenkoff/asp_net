namespace Estudo1.Middleware;

public static class TransactionMiddlewareExtensions
{
    public static IApplicationBuilder UseAllMiddlewares(this IApplicationBuilder builder)
    {
        builder.UseGlobalErrorHandlerMiddleware();
        builder.UseMyMiddleware();
        return builder;

    }
}


public class AllMiddlewares
{
    public AllMiddlewares(ref WebApplication app)
    {
        app.UseMyMiddleware();
    }
}