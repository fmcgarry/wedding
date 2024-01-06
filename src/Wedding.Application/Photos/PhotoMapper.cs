using Wedding.Core.Entities;
using Wedding.Core.Interfaces;

namespace Wedding.UseCases.Photos;

public class PhotoMapper : IEntityModelMapper<Photo, PhotoModel>
{
    public Photo MapEntityFrom(PhotoModel model)
    {
        throw new NotImplementedException();
    }

    public PhotoModel MapModelFrom(Photo entity)
    {
        throw new NotImplementedException();
    }
}
