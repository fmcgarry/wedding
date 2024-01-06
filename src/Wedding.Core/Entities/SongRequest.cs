using Wedding.Core.Interfaces;

namespace Wedding.Core.Entities;

public class SongRequest : IEntity
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public string? Artist { get; set; }
}

