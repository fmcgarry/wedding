using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Wedding.Api.Guests.DTOs;
using Wedding.Core.Entities;
using Wedding.Core.Interfaces;

namespace Wedding.Api.Guests.Endpoints;

public static class AddGuest
{
    public static async Task<CreatedAtRoute<GuestDTO>> Handler([FromBody] GuestDTO guest, [FromServices] IGuestService guestService)
    {
        var guestModel = new Guest()
        {
            Id = Guid.NewGuid(),
            Name = "",
            Email = "",
        };

        await guestService.AddGuestAsync(guestModel);

        return TypedResults.CreatedAtRoute(guest);
    }
}
