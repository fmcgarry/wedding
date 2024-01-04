﻿using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Wedding.Api.Guests.DTOs;
using Wedding.Core.Entities;
using Wedding.Core.Interfaces;

namespace Wedding.Api.Guests.Endpoints;

public static class UpdateGuest
{
    public static async Task<Results<NotFound, NoContent>> Handler([FromRoute] Guid id, [FromBody] GuestDTO guest, [FromServices] IGuestService guestService)
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