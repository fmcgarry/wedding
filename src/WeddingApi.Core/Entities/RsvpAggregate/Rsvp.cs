namespace WeddingApi.Core.Entities.RsvpAggregate;

public class Rsvp
{
    public Guid Id { get; set; }
    public Guid PrimaryGuestId { get; set; }
    public bool Attending { get; set; }
    public FoodChoice DinnerSelection { get; set; }
}
