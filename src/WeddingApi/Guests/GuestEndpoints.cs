using Swashbuckle.AspNetCore.Annotations;

namespace WeddingApi.Guests;

public static partial class GuestEndpoints
{
    public static void MapGuestApi(this WebApplication app)
    {
        app.MapGroup("/guests")
            .MapGuestEndpoints()
            .WithTags("Guests");
    }

    private static RouteGroupBuilder MapGuestEndpoints(this RouteGroupBuilder group)
    {
        group.MapGet("/", GetGuests)
            .WithMetadata(new SwaggerOperationAttribute("Gets all guests"));

        group.MapPost("/", AddGuest)
            .WithMetadata(new SwaggerOperationAttribute("Adds a guest"));

        group.MapGet("/{id}", GetGuest)
            .WithMetadata(new SwaggerOperationAttribute("Gets a single guest by id"));

        group.MapPut("/{id}", UpdateGuest)
            .WithMetadata(new SwaggerOperationAttribute("Updates a guest by id"));

        group.MapDelete("/{id}", DeleteGuest)
            .WithMetadata(new SwaggerOperationAttribute("Deletes a guest by id"));

        return group;
    }
}
