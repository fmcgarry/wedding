using Wedding.Core.Interfaces;

namespace Wedding.Core.Entities.GuestAggregate;

public class Guest : IEntity
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public string? Email { get; set; }
    public bool Attending { get; set; }
    public FoodChoice DinnerSelection { get; set; }
}