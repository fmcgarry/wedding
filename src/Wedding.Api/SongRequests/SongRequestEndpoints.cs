using Swashbuckle.AspNetCore.Annotations;
using Wedding.Api.SongRequests.Endpoints;

namespace Wedding.Api.SongRequests;

public static class SongRequestEndpoints
{
    public static void MapSongRequestApi(this WebApplication app)
    {
        app.MapGroup("/songrequests")
            .MapSongRequestEndpoints()
            .WithTags("Song Requests");
    }

    private static RouteGroupBuilder MapSongRequestEndpoints(this RouteGroupBuilder group)
    {
        group.MapGet("/", GetSongRequests.Handler)
            .WithMetadata(new SwaggerOperationAttribute("Gets all song requests"));

        group.MapPost("/", AddSongRequest.Handler)
            .WithMetadata(new SwaggerOperationAttribute("Add a new song request"));

        group.MapGet("/{id}", GetSongRequest.Handler)
            .WithMetadata(new SwaggerOperationAttribute("Get a specific song request"));

        group.MapPut("/{id}", UpdateSongRequest.Handler)
            .WithMetadata(new SwaggerOperationAttribute("Update a specific song request"));

        group.MapDelete("/{id}", RemoveSongRequest.Handler)
            .WithMetadata(new SwaggerOperationAttribute("Delete a specifc song request"));

        return group;
    }
}
