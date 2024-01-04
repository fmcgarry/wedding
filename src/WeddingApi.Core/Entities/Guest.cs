using WeddingApi.Core.Interfaces;

namespace WeddingApi.Core.Entities;

public class Guest : IEntity
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
}
