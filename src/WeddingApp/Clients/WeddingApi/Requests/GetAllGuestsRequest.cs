namespace WeddingApp.Clients.WeddingApi.Requests;

public class GetAllGuestsRequest : IClientRequest
{
    public HttpMethod Method => HttpMethod.Get;

    public string Uri => "guests";
}