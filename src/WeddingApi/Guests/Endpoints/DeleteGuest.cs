using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Wedding.Core.Interfaces;

namespace Wedding.Api.Guests.Endpoints;

public static class DeleteGuest
{
    public static async Task<Results<NotFound, NoContent>> Handler([FromRoute] Guid id, [FromServices] IGuestService guestService)
    {
        var guestToRemove = await guestService.GetGuestByIdAsync(id);
        if (guestToRemove == null)
        {
            return TypedResults.NotFound();
        }

        await guestService.RemoveGuestAsync(id);

        return TypedResults.NoContent();
    }
}
