namespace Carquitecture.Application.Shared.ErrorHandling;

public class BaseResult
{
    protected BaseResult(bool isSuccess, Error error) 
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

    public static BaseResult Success() => new (true, Error.None);

    public static BaseResult Failure(Error error) => new (false, error);
}
