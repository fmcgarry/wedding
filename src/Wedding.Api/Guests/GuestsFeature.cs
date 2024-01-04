using Swashbuckle.AspNetCore.Annotations;
using Wedding.Api.Guests.DTOs;
using Wedding.Api.Guests.Endpoints;
using Wedding.Core.Entities;
using Wedding.Core.Interfaces;

namespace Wedding.Api.Guests;

public class GuestsFeature : IFeature
{
    public IServiceCollection RegisterServices(IServiceCollection services)
    {
        services.AddTransient<IEntityModelMapper<Guest, GuestDTO>, GuestMapper>();

        return services;
    }

    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        var group = endpoints.MapGroup("/guests").WithTags("Guests");

        group.MapGet("/", GetGuests.Handler)
            .WithMetadata(new SwaggerOperationAttribute("Gets all guests"));

        group.MapPost("/", AddGuest.Handler)
            .WithMetadata(new SwaggerOperationAttribute("Adds a guest"));

        group.MapGet("/{id}", GetGuest.Handler)
            .WithMetadata(new SwaggerOperationAttribute("Gets a single guest by id"));

        group.MapPut("/{id}", UpdateGuest.Handler)
            .WithMetadata(new SwaggerOperationAttribute("Updates a guest by id"));

        group.MapDelete("/{id}", DeleteGuest.Handler)
            .WithMetadata(new SwaggerOperationAttribute("Deletes a guest by id"));

        return group;
    }
}
