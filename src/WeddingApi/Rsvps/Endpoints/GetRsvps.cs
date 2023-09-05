using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WeddingApi.Core.Interfaces;
using WeddingApi.Rsvps.Dtos;

namespace WeddingApi.Rsvps.Endpoints;

public static class GetRsvps
{
    public static async Task<Ok<List<RsvpDTO>>> Handler([FromServices] IRsvpService rsvpService)
    {
        var rsvps = await rsvpService.GetRsvpsAsync();

        var results = new List<RsvpDTO>();

        foreach (var rsvp in rsvps)
        {
            results.Add(new RsvpDTO()
            {

            });
        }

        return TypedResults.Ok(results);
    }
}
