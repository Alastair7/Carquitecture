using Carquitecture.Application.Shared.ErrorHandling;
using DispatchR.Abstractions.Send;
using Microsoft.Extensions.Logging;

namespace Carquitecture.Application.Shared.Behaviors;

public class LoggingBehavior<TCommand, TResult>
    : IPipelineBehavior<TCommand, Task<TResult>>
    where TCommand : class, IRequest<TCommand, Task<TResult>>
    where TResult : Result
{
    private readonly ILogger<LoggingBehavior<TCommand, TResult>> _logger;

    public LoggingBehavior(ILogger<LoggingBehavior<TCommand, TResult>> logger)
    {
        _logger = logger;
    }

    public required IRequestHandler<TCommand, Task<TResult>> NextPipeline { get; set; }

    public async Task<TResult> Handle(TCommand request, CancellationToken cancellationToken)
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