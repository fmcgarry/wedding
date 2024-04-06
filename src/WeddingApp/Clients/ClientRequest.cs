using System.Text.Json.Serialization;

namespace WeddingApp.Clients;

public abstract class ClientRequest(HttpMethod method, string uri)
{
    [JsonIgnore]
    public HttpMethod Method => method;

    [JsonIgnore]
    public string Uri => uri;

    public virtual HttpContent? GetContent() => null;

    public virtual bool IsValid() => true;
}