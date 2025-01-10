using Wedding.Core.Common;

namespace Wedding.Core.SongRequests;

public class SongRequest : IEntity
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public string? Artist { get; set; }
    public Guid RequestedBy { get; set; }
    public DateTime RequestedDate { get; set; }
}