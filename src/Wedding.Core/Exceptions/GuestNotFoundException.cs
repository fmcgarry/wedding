namespace Wedding.Core.Exceptions;

[Serializable]
public class GuestNotFoundException : Exception
{
    public GuestNotFoundException()
    {
    }

    public GuestNotFoundException(string? message) : base(message)
    {
    }

    public GuestNotFoundException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    public GuestNotFoundException(Guid id) : this($"Could not find guest with id '{id}'.")
    {
    }
}
