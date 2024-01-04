using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Wedding.Core.Interfaces;

namespace Wedding.Api.Photos.Endpoints;

public class GetPhotos
{
    public static async Task<Ok<IEnumerable<string>>> Handler([FromServices] IPhotoService photoService)
    {
        var photos = await photoService.GetPhotoUrlsAsync();

        return TypedResults.Ok(photos);
    }

}
