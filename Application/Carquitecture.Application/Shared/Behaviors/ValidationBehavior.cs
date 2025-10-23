using DispatchR.Abstractions.Send;
using FluentValidation;

namespace Carquitecture.Application.Shared.Behaviors;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, Task<TResponse>>
    where TRequest : class, IRequest<TRequest, Task<TResponse>>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public required IRequestHandler<TRequest, Task<TResponse>> NextPipeline { get; set; }

    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken)
    {
        if (!_validators.Any())
        {
            return await NextPipeline.Handle(request, cancellationToken);
        }

        var context = new ValidationContext<TRequest>(request);

        var errorsDictionary = _validators
            .Select(x => x.Validate(context))
            .SelectMany(x => x.Errors)
            .Where(x => x != null)
            .ToList();

        if (errorsDictionary.Count != 0) 
        {
            throw new ValidationException(errorsDictionary);
        }

        return await NextPipeline.Handle(request, cancellationToken);
    }
}
