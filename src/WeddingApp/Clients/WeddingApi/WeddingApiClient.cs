using WeddingApp.Clients.WeddingApi.Models;
using WeddingApp.Clients.WeddingApi.Requests;

namespace WeddingApp.Clients.WeddingApi;

public class WeddingApiClient(ILogger<WeddingApiClient> _logger, HttpClient httpClient) : Client(httpClient), IWeddingApiClient
{
    public async Task<ClientResult> AddGuestAsync(Guest guest)
    {
        try
        {
            _logger.LogTrace("Adding new guest");

            var request = new AddGuestRequest()
            {
                Name = guest.Name,
            };

            await SendRequest(request);

            return ClientResult.Success();
        }
        catch (Exception e)
        {
            _logger.LogError("Failed to add guest: {e}", e);
            return ClientResult.Failure("Failed to add guest.");
        }
    }

    public async Task<ClientResult<IEnumerable<Guest>>> GetAllGuestsAsync()
    {
        try
        {
            _logger.LogTrace("Getting all guests");

            var request = new GetAllGuestsRequest();
            var guests = await SendRequest<IEnumerable<Guest>>(request);

            if (guests is null)
            {
                return ClientResult.Failure<IEnumerable<Guest>>("No guests were found.");
            }

            return ClientResult.Success(guests);
        }
        catch (Exception e)
        {
            _logger.LogError("Failed to get all guests: {e}", e);
            return ClientResult.Failure<IEnumerable<Guest>>("An unexpected error occurred while fetching all guests.");
        }
    }
}