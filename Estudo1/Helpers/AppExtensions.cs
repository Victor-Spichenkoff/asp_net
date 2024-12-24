using Estudo1.Middleware;

namespace Estudo1.Helpers;

public static class AppExtensions
{
    public static void ConfigureApp(this WebApplication app)
    {
        app.UseAllMiddlewares(); // mais legível
        
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();
    }
}