using WeddingApi.Core.Interfaces;
using WeddingApi.Core.Models;

namespace WeddingApi.Core.Services;

public class SongRequestService : ISongRequestService
{
    private readonly List<SongRequest> _songRequests = new();

    public IEnumerable<SongRequest> GetSongRequests()
    {
        return _songRequests;
    }

    public SongRequest? GetSongRequestById(Guid id)
    {
        return _songRequests.FirstOrDefault(sr => sr.Id == id);
    }

    public void AddSongRequest(SongRequest songRequest)
    {
        songRequest.Id = Guid.NewGuid();
        _songRequests.Add(songRequest);
    }

    public void UpdateSongRequest(Guid id, SongRequest updatedSongRequest)
    {
        var existingSongRequest = _songRequests.FirstOrDefault(sr => sr.Id == id);

        if (existingSongRequest != null)
        {
            existingSongRequest.Title = updatedSongRequest.Title;
            existingSongRequest.Artist = updatedSongRequest.Artist;
        }
    }

    public void RemoveSongRequest(Guid id)
    {
        var songRequestToRemove = _songRequests.FirstOrDefault(sr => sr.Id == id);

        if (songRequestToRemove != null)
        {
            _songRequests.Remove(songRequestToRemove);
        }
    }
}

