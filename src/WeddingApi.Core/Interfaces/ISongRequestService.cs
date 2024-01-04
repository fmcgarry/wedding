using Wedding.Core.Entities;

namespace Wedding.Core.Interfaces;

public interface ISongRequestService
{
    Task<IEnumerable<SongRequest>> GetSongRequestsAsync();
    Task<SongRequest?> GetSongRequestByIdAsync(Guid id);
    Task AddSongRequestAsync(SongRequest songRequest);
    Task UpdateSongRequestAsync(Guid id, SongRequest updatedSongRequest);
    Task RemoveSongRequestAsync(Guid id);
}

