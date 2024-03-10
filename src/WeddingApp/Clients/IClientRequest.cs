namespace WeddingApp.Clients;

public interface IClientRequest
{
    public HttpMethod Method { get; }

    public string Uri { get; }

    public HttpContent? GetContent() => null;

    public bool IsValid() => true;
}