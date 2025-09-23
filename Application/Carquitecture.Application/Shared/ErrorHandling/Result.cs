namespace Carquitecture.Application.Shared.ErrorHandling;
public class Result
{
    protected Result(bool isSuccess, Error error)
    {
        if (isSuccess && error != Error.None || !isSuccess && error == Error.None)
        {
            throw new ArgumentException("Unknown error", nameof(error));
        }

        IsSuccess = isSuccess;
        Error = error;
    }

    public bool IsSuccess { get; }

    public bool IsFailure => !IsSuccess;

    public Error Error { get; }

    public static Result Success() => new(true, Error.None);

    public static Result Failure(Error error) => new(false, error);
}

public class Result<T> : Result
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