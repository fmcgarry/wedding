using Wedding.Core.Entities;
using Wedding.Core.Interfaces;

namespace Wedding.Infrastructure.SongRequests;

public interface ISongRequestRepository : IRepository<SongRequest>
{
    Task<IEnumerable<SongRequest>> GetSongRequestsAsync();
    Task<SongRequest?> GetSongRequestByIdAsync(Guid id);
    Task AddSongRequestAsync(SongRequest songRequest);
    Task UpdateSongRequestAsync(Guid id, SongRequest updatedSongRequest);
    Task RemoveSongRequestAsync(Guid id);
}
