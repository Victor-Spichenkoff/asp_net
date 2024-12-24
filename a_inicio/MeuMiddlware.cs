using System.Diagnostics;
using Serilog;
using Serilog.Sinks;

namespace a_inicio
{
    public class TemplateDeUmMiddleware
    {
        private readonly RequestDelegate _next;//delegate == faz a algo e segue esperando

        public TemplateDeUmMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            //Faz algo antes

            //chamar a proxima
            await _next(httpContext);

            //algo depois(volta)
        }
    }



    //Real
    /*
     Cronometra o tempo da requisição (até enviar)
     
     */
    public class MeuMiddleware 
    {
        private readonly RequestDelegate _next;

        public MeuMiddleware(RequestDelegate next)
        {
            _next = next;
        }


        public async Task InvokeAsync(HttpContext httpContext)
        {
            //antes
            var sw = Stopwatch.StartNew();

            await _next(httpContext);
            sw.Stop();

            Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();
            Log.Information($"O tempo foi de {sw.Elapsed.TotalMilliseconds}ms");
        }
    }
}
