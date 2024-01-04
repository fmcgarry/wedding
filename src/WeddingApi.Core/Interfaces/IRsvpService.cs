using Wedding.Core.Entities.RsvpAggregate;

namespace Wedding.Core.Interfaces;

public interface IRsvpService
{
    Task<IEnumerable<Rsvp>> GetRsvpsAsync();
    Task<Rsvp?> GetRsvpByIdAsync(Guid id);
    Task AddRsvpAsync(Rsvp rsvp);
    Task UpdateRsvpAsync(Guid id, Rsvp updatedRsvp);
    Task RemoveRsvpAsync(Guid id);
}
