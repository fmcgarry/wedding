using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WeddingApi.Core.Interfaces;

namespace WeddingApi.Guests;

public static partial class GuestEndpoints
{
    public static async Task<Results<NotFound, NoContent>> DeleteGuest([FromRoute] Guid id, [FromServices] IGuestService guestService)
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
