using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WeddingApi.Core.Interfaces;
using WeddingApi.Guests.DTOs;

namespace WeddingApi.Guests;

public static partial class GuestEndpoints
{
    public static async Task<Ok<List<GuestDTO>>> GetGuests([FromServices] IGuestService guestService)
    {
        var guests = await guestService.GetGuestsAsync();

        var results = new List<GuestDTO>();

        foreach (var guest in guests)
        {
            results.Add(new GuestDTO()
            {

            });
        }

        return TypedResults.Ok(results);
    }
}
