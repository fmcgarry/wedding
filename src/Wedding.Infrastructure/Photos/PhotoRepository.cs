using Wedding.Core.Interfaces;

namespace Wedding.Infrastructure.Photos;

public class PhotoRepository : IPhotoRepository
{
    public async Task<IEnumerable<string>> GetPhotoUrlsAsync()
    {
        throw new NotImplementedException();
    }
}
