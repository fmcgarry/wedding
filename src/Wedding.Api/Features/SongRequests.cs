using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Wedding.Core.Entities;
using Wedding.Core.Interfaces;
using Wedding.UseCases.SongRequests;

namespace Wedding.Api.SongRequests;

public class SongRequests : IFeature
{
    public void MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        var group = endpoints.MapGroup("/songrequests").WithTags("Song Requests");

        group.MapGet("/", GetAllSongRequests)
            .WithMetadata(new SwaggerOperationAttribute("Gets all song requests"));

        group.MapPost("/", AddSongRequest)
            .WithMetadata(new SwaggerOperationAttribute("Add a new song request"));

        group.MapGet("/{id:Guid}", GetSongRequest)
            .WithMetadata(new SwaggerOperationAttribute("Get a specific song request"));

        group.MapPut("/{id:Guid}", UpdateSongRequest)
            .WithMetadata(new SwaggerOperationAttribute("Update a specific song request"));

        group.MapDelete("/{id:Guid}", RemoveSongRequest)
            .WithMetadata(new SwaggerOperationAttribute("Delete a specific song request"));
    }

    private static async Task<CreatedAtRoute<SongRequestModel>> AddSongRequest([FromBody] SongRequestModel songRequest, [FromServices] ISongRequestService songRequestService)
    {
        var songRequestModel = new SongRequest()
        {
            Title = ""
        };

        await songRequestService.AddSongRequestAsync(songRequestModel);

        return TypedResults.CreatedAtRoute(songRequest, nameof(AddSongRequest));
    }

    private static async Task<Results<NotFound, Ok<SongRequestModel>>> GetSongRequest([FromRoute] Guid id, [FromServices] ISongRequestService songRequestService)
    {
        var songRequest = await songRequestService.GetSongRequestByIdAsync(id);
        if (songRequest == null)
        {
            return TypedResults.NotFound();
        }

        var songRequestModel = new SongRequestModel();

        return TypedResults.Ok(songRequestModel);
    }

    private static async Task<Ok<List<SongRequestModel>>> GetAllSongRequests([FromServices] ISongRequestService songRequestService)
    {
        var songRequests = await songRequestService.GetSongRequestsAsync();

        var results = new List<SongRequestModel>();

        foreach (var songRequest in songRequests)
        {
            results.Add(new SongRequestModel()
            {
            });
        }

        return TypedResults.Ok(results);
    }

    private static async Task<Results<NotFound, NoContent>> RemoveSongRequest(Guid id, [FromServices] ISongRequestService songRequestService)
    {
        var songRequestToRemove = songRequestService.GetSongRequestByIdAsync(id);

        if (songRequestToRemove is not null)
        {
            await songRequestService.RemoveSongRequestAsync(id);
        }

        return TypedResults.NoContent();
    }

    private static async Task<Results<NotFound, NoContent>> UpdateSongRequest([FromRoute] Guid id, [FromBody] SongRequestModel updatedSongRequest, [FromServices] ISongRequestService songRequestService)
    {
        var existingSongRequest = songRequestService.GetSongRequestByIdAsync(id);
        if (existingSongRequest is null)
        {
            return TypedResults.NotFound();
        }

        var songRequest = new SongRequest()
        {
            Title = ""
        };

        await songRequestService.UpdateSongRequestAsync(id, songRequest);

        return TypedResults.NoContent();
    }
}