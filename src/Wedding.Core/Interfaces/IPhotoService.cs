namespace Wedding.Core.Interfaces;

public interface IPhotoService
{
    public Task<IEnumerable<string>> GetPhotoUrlsAsync();
}
