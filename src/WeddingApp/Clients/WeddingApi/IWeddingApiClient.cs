using WeddingApp.Clients.WeddingApi.Models;

namespace WeddingApp.Clients.WeddingApi;

public interface IWeddingApiClient
{
    /// <summary>
    /// Add a new guest.
    /// </summary>
    /// <param name="guest"></param>
    /// <returns><c>true</c> if successful; Otherwise, <c>false</c>.</returns>
    Task<bool> AddGuestAsync(Guest guest);

    /// <summary>
    /// Get all guests.
    /// </summary>
    /// <returns>A collection of <c>Guest</c> objects; Otherwise, <c>null</c> if the call was unsuccessful.</returns>
    Task<IEnumerable<Guest>?> GetAllGuestsAsync();
}