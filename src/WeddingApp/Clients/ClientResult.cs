namespace WeddingApp.Clients;

public class ClientResult
{
    protected ClientResult(bool isSuccessful, string? error = null)
    {
        IsSuccess = isSuccessful;
        Error = error ?? string.Empty;
    }

    public string Error { get; init; }
    public bool IsFailure => !IsSuccess;
    public bool IsSuccess { get; init; }

    public static ClientResult Failure(string message) => new(false, message);

    public static ClientResult<T> Failure<T>(string message) => new(default!, false, message);

    public static ClientResult Success() => new(true);

    public static ClientResult<T> Success<T>(T value) => new(value, true);
}

public class ClientResult<T> : ClientResult
{
    protected internal ClientResult(T value, bool isSucessful, string? message = null) : base(isSucessful, message)
    {
        Value = value;
    }

    public T Value { get; init; }
}