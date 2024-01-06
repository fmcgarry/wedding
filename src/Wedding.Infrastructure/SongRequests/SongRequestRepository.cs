using Wedding.Core.Entities;

namespace Wedding.Infrastructure.SongRequests;

public class SongRequestRepository : ISongRequestRepository
{
    private readonly List<SongRequest> _songRequests = new();

    public async Task<IEnumerable<SongRequest>> GetSongRequestsAsync()
    {
        return _songRequests;
    }

    public async Task<SongRequest?> GetSongRequestByIdAsync(Guid id)
    {
        return _songRequests.FirstOrDefault(sr => sr.Id == id);
    }

    public async Task AddSongRequestAsync(SongRequest songRequest)
    {
        songRequest.Id = Guid.NewGuid();
        _songRequests.Add(songRequest);
    }

    public async Task UpdateSongRequestAsync(Guid id, SongRequest updatedSongRequest)
    {
        var existingSongRequest = _songRequests.FirstOrDefault(sr => sr.Id == id);

        if (existingSongRequest != null)
        {
            existingSongRequest.Title = updatedSongRequest.Title;
            existingSongRequest.Artist = updatedSongRequest.Artist;
        }
    }

    public async Task RemoveSongRequestAsync(Guid id)
    {
        var songRequestToRemove = _songRequests.FirstOrDefault(sr => sr.Id == id);

        if (songRequestToRemove != null)
        {
            _songRequests.Remove(songRequestToRemove);
        }
    }
}
