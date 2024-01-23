namespace Wedding.Core.Interfaces;

public interface IPhotoClient
{
    public Task<IEnumerable<string>> GetPhotoUrlsAsync();
}