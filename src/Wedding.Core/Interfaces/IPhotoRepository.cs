using Wedding.Core.Entities;

namespace Wedding.Core.Interfaces;

public interface IPhotoRepository : IRepository<Photo>
{
    public Task<IEnumerable<string>> GetPhotoUrlsAsync();
}
