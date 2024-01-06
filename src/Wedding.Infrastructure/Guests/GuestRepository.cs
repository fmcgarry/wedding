using Wedding.Core.Entities;
using Wedding.Core.Interfaces;

namespace Wedding.Infrastructure.Guests;

public class GuestRepository : IGuestRepository
{
    private readonly List<Guest> _guests = new();

    public async Task<IEnumerable<Guest>> GetGuestsAsync()
    {
        return _guests;
    }

    public async Task<Guest?> GetGuestByIdAsync(Guid id)
    {
        return _guests.FirstOrDefault(g => g.Id == id);
    }

    public async Task AddGuestAsync(Guest guest)
    {
        guest.Id = Guid.NewGuid();
        _guests.Add(guest);
    }

    public async Task UpdateGuestAsync(Guid id, Guest updatedGuest)
    {
        var existingGuest = _guests.FirstOrDefault(g => g.Id == id);

        if (existingGuest != null)
        {
            existingGuest.Name = updatedGuest.Name;
            existingGuest.Email = updatedGuest.Email;
        }
    }

    public async Task RemoveGuestAsync(Guid id)
    {
        var guestToRemove = _guests.FirstOrDefault(g => g.Id == id);

        if (guestToRemove != null)
        {
            _guests.Remove(guestToRemove);
        }
    }
}
