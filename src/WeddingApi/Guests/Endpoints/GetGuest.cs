using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WeddingApi.Core.Interfaces;
using WeddingApi.Guests.DTOs;

namespace WeddingApi.Guests.Endpoints;

public static class GetGuest
{
    public static async Task<Results<NotFound, Ok<GuestDTO>>> Handler([FromRoute] Guid id, [FromServices] IGuestService guestService)
    {
        var guest = await guestService.GetGuestByIdAsync(id);
        if (guest is null)
        {
            return TypedResults.NotFound();
        }

        return TypedResults.Ok(new GuestDTO()
        {

        });
    }
}