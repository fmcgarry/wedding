using WeddingApp.Components.Pages.Rsvp;

namespace WeddingApp.Clients.WeddingApi;

public class WeddingApiClient(ILogger<WeddingApiClient> _logger, HttpClient _httpClient) : IWeddingApiClient
{
    public async Task SendRsvpAsync(RsvpModel rsvp)
    {
        _logger.LogTrace("Sending Rsvp");
    }
}