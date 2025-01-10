namespace Wedding.Core.Exceptions;

[Serializable]
public class GuestNotFoundException : Exception
{
    private GuestNotFoundException()
    {
    }

    private GuestNotFoundException(string? message) : base(message)
    {
    }

    private GuestNotFoundException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    public GuestNotFoundException(Guid id) : this($"Could not find guest with id '{id}'.")
    {
    }

    public GuestNotFoundException(Guid id, Exception? innerException) : this($"Could not find guest with id '{id}'.", innerException)
    {
    }
}
