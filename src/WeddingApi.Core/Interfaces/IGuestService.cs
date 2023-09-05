using WeddingApi.Core.Entities;

namespace WeddingApi.Core.Interfaces;

public interface IGuestService
{
    Task<IEnumerable<Guest>> GetGuestsAsync();
    Task<Guest?> GetGuestByIdAsync(Guid id);
    Task AddGuestAsync(Guest guest);
    Task UpdateGuestAsync(Guid id, Guest updatedGuest);
    Task RemoveGuestAsync(Guid id);

}
