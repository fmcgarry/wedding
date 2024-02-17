namespace Wedding.Core.Entities.GuestAggregate;
public class Address
{
    public string? Line1 { get; set; }
    public string? City { get; set; }
    public StateTerritory? State { get; set; }
    public string? Zip { get; set; }
    public string? Phone { get; set; }
}
