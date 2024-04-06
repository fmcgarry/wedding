using WeddingApp.Clients.WeddingApi.Models;
using WeddingApp.Clients.WeddingApi.Requests;

namespace WeddingApp.Clients.WeddingApi;

public class WeddingApiClient(ILogger<WeddingApiClient> _logger, HttpClient httpClient) : Client(httpClient), IWeddingApiClient
{
    public async Task<bool> AddGuestAsync(Guest guest)
    {
        try
        {
            _logger.LogTrace("Adding new guest");

            var request = new AddGuestRequest()
            {
                Email = "",
                Name = guest.Name,
            };

            await SendRequest(request);

            return true;
        }
        catch (Exception e)
        {
            _logger.LogError("Failed to add guest: {e}", e);
            return false;
        }
    }

    public async Task<IEnumerable<Guest>?> GetAllGuestsAsync()
    {
        try
        {
            _logger.LogTrace("Getting all guests");

            var request = new GetAllGuestsRequest();
            var guests = await SendRequest<IEnumerable<Guest>>(request);

            return guests ?? [];
        }
        catch (Exception e)
        {
            _logger.LogError("Failed to get all guests: {e}", e);
            return null;
        }
    }
}