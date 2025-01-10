using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Wedding.UseCases.SongRequests;
using Wedding.UseCases.SongRequests.Commands;
using Wedding.UseCases.SongRequests.Queries;

namespace Wedding.Api.SongRequests;

/// <summary>
/// This feature demonstrates using private static methods for endpoint handlers.
/// </summary>
public class SongRequests : IFeature
{
    public void MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        var group = endpoints.MapGroup("/songrequests").WithTags("Song Requests");

        group.MapGet("/", GetAllSongRequests)
            .WithMetadata(new SwaggerOperationAttribute("Lists all song requests"));

        group.MapPost("/", AddSongRequest)
            .WithMetadata(new SwaggerOperationAttribute("Add a new song request"));

        group.MapGet("/{id:Guid}", GetSongRequest)
            .WithMetadata(new SwaggerOperationAttribute("Get a specific song request"));

        group.MapPut("/{id:Guid}", UpdateSongRequest)
            .WithMetadata(new SwaggerOperationAttribute("Update a specific song request"));

        group.MapDelete("/{id:Guid}", RemoveSongRequest)
            .WithMetadata(new SwaggerOperationAttribute("Delete a specific song request"));
    }

    private static async Task<CreatedAtRoute<SongRequestModel>> AddSongRequest([FromBody] SongRequestModel songRequest, [FromServices] IMediator mediator)
    {
        await mediator.Send(new AddSongRequestCommand(songRequest));
        return TypedResults.CreatedAtRoute(songRequest, nameof(AddSongRequest));
    }
    private static async Task<Ok<IEnumerable<SongRequestModel>>> GetAllSongRequests([FromServices] IMediator mediator)
    {
        var songRequests = await mediator.Send(new ListSongRequestsQuery());
        return TypedResults.Ok(songRequests);
    }

    private static async Task<Results<NotFound, Ok<SongRequestModel>>> GetSongRequest([FromRoute] Guid id, [FromServices] IMediator mediator)
    {
        var songRequest = await mediator.Send(new GetSongRequestByIdQuery(id));
        return TypedResults.Ok(songRequest);
    }
    private static async Task<Results<NotFound, NoContent>> UpdateSongRequest([FromRoute] Guid id, [FromBody] SongRequestModel updatedSongRequest, [FromServices] IMediator mediator)
    {
        await mediator.Send(new UpdateSongRequestCommand());
        return TypedResults.NoContent();
    }

    private static async Task<Results<NotFound, NoContent>> RemoveSongRequest(Guid id, [FromServices] IMediator mediator)
    {
        await mediator.Send(new RemoveSongRequestCommand(id));
        return TypedResults.NoContent();
    }
}