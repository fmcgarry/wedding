using WeddingApi.Core.Models;

namespace WeddingApi.Core.Interfaces;

public interface ISongRequestService
{
    IEnumerable<SongRequest> GetSongRequests();
    SongRequest? GetSongRequestById(Guid id);
    void AddSongRequest(SongRequest songRequest);
    void UpdateSongRequest(Guid id, SongRequest updatedSongRequest);
    void RemoveSongRequest(Guid id);
}

