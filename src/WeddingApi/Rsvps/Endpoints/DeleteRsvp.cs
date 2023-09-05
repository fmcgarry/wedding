using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WeddingApi.Core.Interfaces;

namespace WeddingApi.Rsvps.Endpoints;

public static class DeleteRsvp
{
    public static async Task<Results<NotFound, NoContent>> Handler([FromRoute] Guid id, [FromServices] IRsvpService rsvpService)
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
