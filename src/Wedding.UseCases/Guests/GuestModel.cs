namespace Wedding.UseCases.Guests;

public class GuestModel
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public string? Email { get; set; }
}