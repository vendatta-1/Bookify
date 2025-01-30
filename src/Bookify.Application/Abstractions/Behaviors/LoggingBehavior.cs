using Bookify.Application.Abstractions.Messaging;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Bookify.Application.Abstractions.Behaviors;

public class LoggingBehavior<TRequest, TResponse> :
    IPipelineBehavior<TRequest, TResponse>
where TRequest : IBaseCommand

{
    public LoggingBehavior(ILogger<TRequest> logger)
    {
        Logger = logger;
    }

    private ILogger<TRequest> Logger { get; }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var name = request.GetType().Name;
        try
        {
            Logger.LogInformation($"Executing Command {name}");
            var result = await next();
            Logger.LogInformation($"Command {name} processed successfully");
            return result;
        }
        catch (Exception e)
        {
            Logger.LogError(exception: e, $"Command {name} processed failed");
            throw;
        }
    }
}