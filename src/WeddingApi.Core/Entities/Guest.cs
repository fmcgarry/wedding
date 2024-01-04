using Wedding.Core.Interfaces;

namespace Wedding.Core.Entities;

public class Guest : IEntity
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
}
