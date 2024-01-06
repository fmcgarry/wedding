using Wedding.Core.Interfaces;

namespace Wedding.Core.Entities;

public class Photo : IEntity
{
    public string Url { get; set; } = string.Empty;
}
