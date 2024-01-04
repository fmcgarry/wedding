using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Wedding.Api.Rsvps.DTOs;
using Wedding.Core.Entities.RsvpAggregate;
using Wedding.Core.Interfaces;

namespace Wedding.Api.Rsvps.Endpoints;

public class GetRsvps
{
    public void MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/rsvps", Handler)
            .WithMetadata(new SwaggerOperationAttribute("Gets all RSVPs"));
    }

    private static async Task<Results<NotFound, Ok<List<RsvpDTO>>>> Handler([FromServices] IRsvpService rsvpService, [FromServices] IEntityModelMapper<Rsvp, RsvpDTO> mapper, [FromQuery] Guid? id)
    {
        var results = new List<RsvpDTO>();

        if (id is not null)
        {
            var rsvp = await rsvpService.GetRsvpByIdAsync(id.Value);

            if (rsvp is not null)
            {
                var rsvpDTO = mapper.MapModelFrom(rsvp);
                results.Add(rsvpDTO);
            }
            else
            {
                return TypedResults.NotFound();
            }
        }
        else
        {
            var rsvps = await rsvpService.GetRsvpsAsync();

            foreach (var rsvp in rsvps)
            {
                var rsvpDTO = mapper.MapModelFrom(rsvp);
                results.Add(rsvpDTO);
            }
        }

        return TypedResults.Ok(results);
    }
}
