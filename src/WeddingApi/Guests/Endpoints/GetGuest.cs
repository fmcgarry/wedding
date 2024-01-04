using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Wedding.Api.Guests.DTOs;
using Wedding.Core.Interfaces;

namespace Wedding.Api.Guests.Endpoints;

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