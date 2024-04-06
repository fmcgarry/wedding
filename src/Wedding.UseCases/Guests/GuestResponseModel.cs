namespace Wedding.UseCases.Guests;

public class GuestResponseModel
{
    public enum Dinner
    {
        None,
        Chicken,
        Meatloaf
    }

    public string? AddressLine1 { get; set; }
    public string? City { get; set; }
    public Dinner? DinnerSelection { get; set; }
    public string? Email { get; set; }
    public required Guid Id { get; set; }
    public bool IsAttending { get; set; }
    public required string Name { get; set; }
    public string? Phone { get; set; }
    public DateTime? RsvpDate { get; set; }
    public string? State { get; set; }
    public string? Zip { get; set; }
}