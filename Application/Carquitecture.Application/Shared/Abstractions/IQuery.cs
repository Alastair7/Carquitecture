using DispatchR.Abstractions.Send;

namespace Carquitecture.Application.Shared.Abstractions;

public interface IQuery<TRequest, TResponse>: IRequest<TRequest, Task<TResponse>>
    where TRequest : class
{ }