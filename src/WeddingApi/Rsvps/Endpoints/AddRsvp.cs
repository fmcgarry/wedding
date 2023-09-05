using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WeddingApi.Core.Entities.RsvpAggregate;
using WeddingApi.Core.Interfaces;
using WeddingApi.Rsvps.Dtos;

namespace WeddingApi.Rsvps.Endpoints
{
    public static class AddRsvp
    {
        public static async Task<Ok> Handler([FromBody] RsvpDTO rsvp, [FromServices] IRsvpService rsvpService)
        {
            var rsvpModel = new Rsvp()
            {

            };

            await rsvpService.AddRsvpAsync(rsvpModel);

            return TypedResults.Ok();
        }
    }
}
