using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Wedding.Api.Rsvps.DTOs;
using Wedding.Core.Entities.RsvpAggregate;
using Wedding.Core.Interfaces;

namespace Wedding.Api.Rsvps.Endpoints;

public class UpdateRsvp
{
    public void MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPut("/{id}", Handler)
            .WithMetadata(new SwaggerOperationAttribute("Update an RSVP"));
    }

    private static async Task<Results<NotFound, NoContent>> Handler([FromRoute] Guid id, [FromBody] RsvpDTO rsvp, [FromServices] IRsvpService rsvpService)
    {
        var existingRsvp = await rsvpService.GetRsvpByIdAsync(id);
        if (existingRsvp == null)
        {
            return TypedResults.NotFound();
        }

        var rsvpModel = new Rsvp();

        await rsvpService.UpdateRsvpAsync(id, rsvpModel);

        return TypedResults.NoContent();
    }
}
