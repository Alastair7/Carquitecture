using Carquitecture.Application.Shared.Abstractions;
using DispatchR.Abstractions.Send;
using Microsoft.Extensions.Logging;

namespace Carquitecture.Application.Shared.Behaviors;

public class LoggingBehavior<TCommand, TResponse>
    : IPipelineBehavior<TCommand, Task<TResponse>>
    where TCommand : class, ICommand<TCommand, TResponse>
{
    private readonly ILogger<LoggingBehavior<TCommand, TResponse>> _logger;

    public LoggingBehavior(ILogger<LoggingBehavior<TCommand, TResponse>> logger)
    {
        _logger = logger;
    }

    public required IRequestHandler<TCommand, Task<TResponse>> NextPipeline { get; set; }

    public async Task<TResponse> Handle(TCommand request, CancellationToken cancellationToken)
    {
        // Create generic behavior that only gets the command.
        _logger.LogInformation("Handling {RequestType} with data: {@RequestData}", typeof(TCommand).Name, request);
        try
        {
            var handlerResponse =  await NextPipeline.Handle(request, cancellationToken);

            _logger.LogInformation("Operation completed succesfully");

            return handlerResponse;
        }
        catch (Exception ex) 
        {
            _logger.LogError($"Error during operation: {ex.Message}");
            throw;
        }    
    }
}