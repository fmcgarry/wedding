using Wedding.Core.Entities.GuestAggregate;

namespace Wedding.Core.Interfaces;

public interface IGuestRepository : IRepository<Guest>
{
    Task<IEnumerable<Guest>> GetGuestsAsync();
    Task<Guest?> GetGuestByIdAsync(Guid id);
    Task AddGuestAsync(Guest guest);
    Task UpdateGuestAsync(Guid id, Guest updatedGuest);
    Task RemoveGuestAsync(Guid id);
}
