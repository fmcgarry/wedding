namespace WeddingApi.Core.Interfaces;

public interface IPhotoService
{
    public Task<IEnumerable<string>> GetPhotoUrlsAsync();
}
