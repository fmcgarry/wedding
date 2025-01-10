using Wedding.Core.Common;

namespace Wedding.Core.Guests.Entities.GuestAggregate;

public class Guest : IEntity
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public string? Email { get; set; }
    public Address? Address { get; set; }
    public bool IsAttending { get; private set; }
    public DateTime? RsvpDate { get; set; }
    public FoodChoice? DinnerSelection { get; set; }
    public Guid? InvitedBy { get; set; }
    public string? Phone { get; set; }

    public void SetAttending(FoodChoice foodChoice)
    {
        IsAttending = true;
        DinnerSelection = foodChoice;
        RsvpDate = DateTime.UtcNow;
    }

    public void Bailed()
    {
        IsAttending = false;
        DinnerSelection = FoodChoice.None;
        RsvpDate = DateTime.MinValue;
    }
}