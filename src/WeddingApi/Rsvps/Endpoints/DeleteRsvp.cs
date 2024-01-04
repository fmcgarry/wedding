using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WeddingApi.Core.Interfaces;

namespace WeddingApi.Rsvps.Endpoints;

public class DeleteRsvp
{
    public void MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapDelete("/rsvps/{id}", Handler)
            .WithMetadata(new SwaggerOperationAttribute("Remove an RSVP"));
    }

    private static async Task<Results<NotFound, NoContent>> Handler([FromRoute] Guid id, [FromServices] IRsvpService rsvpService)
    {
        var rsvpToRemove = await rsvpService.GetRsvpByIdAsync(id);
        if (rsvpToRemove is null)
        {
            return TypedResults.NotFound();
        }

        await rsvpService.RemoveRsvpAsync(id);

        return TypedResults.NoContent();
    }
}
