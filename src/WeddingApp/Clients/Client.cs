namespace WeddingApp.Clients;

public class Client(HttpClient _httpClient)
{
    protected async Task SendRequest(ClientRequest request, CancellationToken cancellationToken = default)
    {
        await SendHttpClientRequest(request, cancellationToken);
    }

    protected async Task<T?> SendRequest<T>(ClientRequest request, CancellationToken cancellationToken = default)
    {
        var response = await SendHttpClientRequest(request, cancellationToken);
        return await response.Content.ReadFromJsonAsync<T>(cancellationToken);
    }

    private async Task<HttpResponseMessage> SendHttpClientRequest(ClientRequest request, CancellationToken cancellationToken)
    {
        if (!request.IsValid())
        {
            throw new ArgumentOutOfRangeException(nameof(request), $"Request {request} was not valid.");
        }

        var httpRequestMessage = new HttpRequestMessage(request.Method, request.Uri)
        {
            Content = request.GetContent()
        };

        HttpResponseMessage response = await _httpClient.SendAsync(httpRequestMessage, cancellationToken);

        response.EnsureSuccessStatusCode();

        return response;
    }
}