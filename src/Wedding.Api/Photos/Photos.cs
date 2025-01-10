using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Wedding.UseCases.Photos.Queries;

namespace Wedding.Api.Photos;

/// <summary>
/// This feature demonstrates inlining endpoint handlers.
/// </summary>
public class Photos : IFeature
{
    public void MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        var group = endpoints.MapGroup("/photos").WithTags("Photos");

        group.MapGet("/", async ([FromServices] IMediator mediator) =>
        {
            var results = await mediator.Send(new ListPhotosQuery());
            return TypedResults.Ok(results);
        }).WithMetadata(new SwaggerOperationAttribute("Gets all photos"));
    }
}
