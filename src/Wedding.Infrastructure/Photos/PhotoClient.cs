using Wedding.Core.Interfaces;

namespace Wedding.Infrastructure.Photos;

public class PhotoClient : IPhotoClient
{
    public Task<IEnumerable<string>> GetPhotoUrlsAsync()
    {
        // Use the Google Photos API
        // https://developers.google.com/photos/library/guides/get-started

        throw new NotImplementedException();
    }
}
