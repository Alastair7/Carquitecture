namespace Carquitecture.Application.Shared.ErrorHandling;

public class Result<T> : BaseResult
{
    private readonly T? _value;

    private Result(T value): base(true, Error.None)
    {
        _value = value;
    }

    private Result(Error error) : base(false, error) 
    {
        _value = default;
    }

    public T Value => IsSuccess ? _value! : throw new InvalidOperationException("No value for failure result");

    public static Result<T> Success(T value) => new(value);

    public static new Result<T> Failure(Error error) => new(error);
}