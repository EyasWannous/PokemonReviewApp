using Microsoft.AspNetCore.Mvc.Filters;
using System.Text.Json;

namespace PokemonReviewApp.Filters;

public class LogActivityFilter(ILogger<LogActivityFilter> logger) : IAsyncActionFilter
{
    private readonly ILogger<LogActivityFilter> _logger = logger;

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        _logger.LogInformation(
            "Executing Action: #{context.ActionDescriptor.DisplayName}\n"
            + "On Controller: #{context.Controller}\n"
            + "With Arguments: #{JsonSerializer.Serialize(context.ActionArguments)}\n",
            context.ActionDescriptor.DisplayName,
            context.Controller,
            JsonSerializer.Serialize(context.ActionArguments)
        );

        await next();

        _logger.LogInformation(
            "Action: #{context.ActionDescriptor.DisplayName}\n"
            + "Executed on Controller: #{context.Controller}",
            context.ActionDescriptor.DisplayName,
            context.Controller
        );
    }
}
