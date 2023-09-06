using Swashbuckle.AspNetCore.Annotations;
using WeddingApi.Rsvps.Endpoints;

namespace WeddingApi.Rsvps;

public static class RsvpEndpoints
{
    public static void MapRsvpApi(this WebApplication app)
    {
        app.MapGroup("/rsvps")
            .MapRsvpEndpoints()
            .WithTags("RSVPs");
    }

    private static RouteGroupBuilder MapRsvpEndpoints(this RouteGroupBuilder group)
    {
        group.MapGet("/", GetRsvps.Handler)
            .WithMetadata(new SwaggerOperationAttribute("Gets all RSVPs"));

        group.MapPost("/", AddRsvp.Handler)
            .WithMetadata(new SwaggerOperationAttribute("Add a new RSVP"));

        group.MapGet("/{id}", GetRsvp.Handler)
            .WithMetadata(new SwaggerOperationAttribute("Gets a single RSVP by id"));

        group.MapDelete("/{id}", DeleteRsvp.Handler)
            .WithMetadata(new SwaggerOperationAttribute("Remove an RSVP"));

        group.MapPut("/{id}", UpdateRsvp.Handler)
            .WithMetadata(new SwaggerOperationAttribute("Update an RSVP"));

        return group;
    }
}
