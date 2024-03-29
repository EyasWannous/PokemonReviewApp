using System.Diagnostics;

namespace PokemonReviewApp.Midlewares;

public class ProfilingMiddleware(RequestDelegate next, ILogger<ProfilingMiddleware> logger)
{
    private readonly RequestDelegate _next = next;
    private readonly ILogger<ProfilingMiddleware> _logger = logger;

    public async Task InvokeAsync(HttpContext context)
    {
        var stopwatch = new Stopwatch();
        
        stopwatch.Start();
        await _next(context);
        stopwatch.Stop();

        _logger.LogInformation(
            "Requset #{context.Request.Path} took #{stopwatch.ElapsedMilliseconds} ms to Excute",
            context.Request.Path,
            stopwatch.ElapsedMilliseconds
        );
    }
}
