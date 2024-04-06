namespace WeddingApp.Clients.WeddingApi.Requests;

public class AddGuestRequest() : ClientRequest(HttpMethod.Post, "guests")
{
    public string? AddressLine1 { get; init; }
    public string? City { get; init; }
    public string? Dinner { get; init; }
    public required string Email { get; init; }
    public required string Name { get; init; }
    public string? Phone { get; init; }
    public string? State { get; init; }
    public string? Zip { get; init; }

    public override HttpContent? GetContent()
    {
        return JsonContent.Create(this);
    }
}