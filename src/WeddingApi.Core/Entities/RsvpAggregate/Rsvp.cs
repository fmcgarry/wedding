using WeddingApi.Core.Interfaces;

namespace WeddingApi.Core.Entities.RsvpAggregate;

public class Rsvp : IEntity
{
    public Guid Id { get; set; }
    public Guid PrimaryGuestId { get; set; }
    public bool Attending { get; set; }
    public FoodChoice DinnerSelection { get; set; }
}
