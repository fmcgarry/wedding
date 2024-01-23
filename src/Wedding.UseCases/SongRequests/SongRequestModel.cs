namespace Wedding.UseCases.SongRequests;

public class SongRequestModel
{
    public Guid Id { get; set; }
    public string? Title { get; set; }
    public string? Artist { get; set; }
    public Guid RequestedBy { get; set; }
    public DateTime RequestedDate { get; set; }
}
