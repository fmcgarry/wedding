using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WeddingApi.Core.Entities;
using WeddingApi.Core.Interfaces;
using WeddingApi.Guests.DTOs;

namespace WeddingApi.Guests;

public static partial class GuestEndpoints
{
    public static async Task<Results<NotFound, NoContent>> UpdateGuest([FromRoute] Guid id, [FromBody] GuestDTO guest, [FromServices] IGuestService guestService)
    {
        var guestToRemove = await guestService.GetGuestByIdAsync(id);
        if (guestToRemove == null)
        {
            return TypedResults.NotFound();
        }

        var guestModel = new Guest()
        {
            Name = "",
            Email = ""
        };

        await guestService.UpdateGuestAsync(id, guestModel);

        return TypedResults.NoContent();
    }
}