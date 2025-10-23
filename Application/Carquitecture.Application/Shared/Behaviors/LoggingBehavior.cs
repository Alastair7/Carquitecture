using DispatchR.Abstractions.Send;
using Microsoft.Extensions.Logging;

namespace Carquitecture.Application.Shared.Behaviors;

public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, Task<TResponse>>
    where TRequest : class, IRequest<TRequest, Task<TResponse>>
{
    private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

    public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }

    public required IRequestHandler<TRequest, Task<TResponse>> NextPipeline { get; set; }

    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Handling {RequestType} with data: {@RequestData}", typeof(TRequest).Name, request);
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