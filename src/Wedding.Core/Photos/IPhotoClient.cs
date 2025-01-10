namespace Wedding.Core.Photos;

public interface IPhotoClient
{
    public Task<IEnumerable<string>> GetPhotoUrlsAsync();
}