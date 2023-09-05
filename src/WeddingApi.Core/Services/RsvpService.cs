using WeddingApi.Core.Entities.RsvpAggregate;
using WeddingApi.Core.Interfaces;

namespace WeddingApi.Core.Services;

public class RsvpService : IRsvpService
{
    private readonly List<Rsvp> _rsvps = new();

    public async Task<IEnumerable<Rsvp>> GetRsvpsAsync()
    {
        return _rsvps;
    }

    public async Task<Rsvp?> GetRsvpByIdAsync(Guid id)
    {
        return _rsvps.FirstOrDefault(r => r.Id == id);
    }

    public async Task AddRsvpAsync(Rsvp rsvp)
    {
        rsvp.Id = Guid.NewGuid();
        _rsvps.Add(rsvp);
    }

    public async Task UpdateRsvpAsync(Guid id, Rsvp updatedRsvp)
    {
        var existingRsvp = _rsvps.FirstOrDefault(r => r.Id == id);

        if (existingRsvp != null)
        {
            existingRsvp.GuestId = updatedRsvp.GuestId;
            existingRsvp.Attending = updatedRsvp.Attending;
        }
    }

    public async Task RemoveRsvpAsync(Guid id)
    {
        var rsvpToRemove = _rsvps.FirstOrDefault(r => r.Id == id);

        if (rsvpToRemove != null)
        {
            _rsvps.Remove(rsvpToRemove);
        }
    }
}
