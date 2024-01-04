using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Wedding.Core.Interfaces;

namespace Wedding.Api.Photos;

public static class PhotoEndpoints
{
    public static void MapPhotoApi(this WebApplication app)
    {
        app.MapGroup("/photos")
            .MapPhotoEndpoints()
            .WithTags("Photos");
    }

    private static RouteGroupBuilder MapPhotoEndpoints(this RouteGroupBuilder group)
    {
        group.MapGet("/", GetAllPhotos)
            .WithMetadata(new SwaggerOperationAttribute("Gets all photos"));

        return group;
    }

    private static async Task<IResult> GetAllPhotos([FromServices] IPhotoService photoService)
    {
        var photos = await photoService.GetPhotoUrlsAsync();
        return Results.Ok(photos);
    }
}
