using Swashbuckle.AspNetCore.Annotations;
using Wedding.Api.Guests.Accompanying;
using Wedding.Api.Guests.Add;
using Wedding.Api.Guests.Delete;
using Wedding.Api.Guests.Get;
using Wedding.Api.Guests.GetAll;
using Wedding.Api.Guests.Update;

namespace Wedding.Api.Guests;

/// <summary>
/// This feature demonstrates splitting out endpoint handlers into separate static classes.
/// Useful if your endpoints require specific DTOs.
/// </summary>
public class GuestsFeature : IFeature
{
    public void MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        var group = endpoints.MapGroup("/guests").WithTags("Guests");

        group.MapGet(GetAllGuestsEndpoint.Route, GetAllGuestsEndpoint.Handler)
            .WithMetadata(new SwaggerOperationAttribute(GetAllGuestsEndpoint.Description));

        group.MapPost(AddGuestEndpoint.Route, AddGuestEndpoint.Handler)
            .WithMetadata(new SwaggerOperationAttribute(AddGuestEndpoint.Description));

        group.MapGet(GetGuestEndpoint.Route, GetGuestEndpoint.Handler)
            .WithMetadata(new SwaggerOperationAttribute(GetGuestEndpoint.Description));

        group.MapPut(UpdateGuestEndpoint.Route, UpdateGuestEndpoint.Handler)
            .WithMetadata(new SwaggerOperationAttribute(UpdateGuestEndpoint.Description));

        group.MapDelete(DeleteGuestEndpoint.Route, DeleteGuestEndpoint.Handler)
            .WithMetadata(new SwaggerOperationAttribute(DeleteGuestEndpoint.Description));

        group.MapGet(AccompanyingEndpoint.Route, AccompanyingEndpoint.Handler)
            .WithMetadata(new SwaggerOperationAttribute(AccompanyingEndpoint.Description));
    }
}