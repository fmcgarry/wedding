using Wedding.Core.Common;

namespace Wedding.Core.Photos;

public class Photo : IEntity
{
    public Guid Id { get; set; }
    public string Url { get; set; } = string.Empty;
}