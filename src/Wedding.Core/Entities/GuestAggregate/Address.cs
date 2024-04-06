namespace Wedding.Core.Entities.GuestAggregate;
public class Address
{
    public required Guid Id { get; set; }
    public string? Line1 { get; set; }
    public string? City { get; set; }
    public StateTerritory? State { get; set; }
    public string? Zip { get; set; }
}
