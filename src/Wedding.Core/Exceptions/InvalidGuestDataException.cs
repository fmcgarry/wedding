namespace Wedding.Core.Exceptions;

[Serializable]
public class InvalidGuestDataException : Exception
{
    public InvalidGuestDataException()
    {
    }

    public InvalidGuestDataException(string? message) : base(message)
    {
    }

    public InvalidGuestDataException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
