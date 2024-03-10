using WeddingApp.Clients.WeddingApi.Models;

namespace WeddingApp.Clients.WeddingApi.Requests;

public class AddGuestRequest(Guest _guest) : IClientRequest
{
    public HttpMethod Method => HttpMethod.Post;

    public string Uri => "guests";

    public HttpContent? GetContent()
    {
        return JsonContent.Create(_guest);
    }
}