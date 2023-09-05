using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WeddingApi.Core.Entities.RsvpAggregate;
using WeddingApi.Core.Interfaces;
using WeddingApi.Rsvps.Dtos;

namespace WeddingApi.Rsvps.Endpoints;

public static class UpdateRsvp
{
    public static async Task<Results<NotFound, NoContent>> Handler([FromRoute] Guid id, [FromBody] RsvpDTO rsvp, [FromServices] IRsvpService rsvpService)
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
