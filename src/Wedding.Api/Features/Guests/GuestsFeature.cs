﻿using Swashbuckle.AspNetCore.Annotations;
using Wedding.Api.Features.Guests.Accompanying;
using Wedding.Api.Features.Guests.Add;
using Wedding.Api.Features.Guests.Delete;
using Wedding.Api.Features.Guests.Get;
using Wedding.Api.Features.Guests.GetAll;
using Wedding.Api.Features.Guests.Rsvp;
using Wedding.Api.Features.Guests.Update;

namespace Wedding.Api.Features.Guests;

/// <summary>
/// This feature demonstrates splitting out endpoint handlers into separate static classes.
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

        group.MapPut(UpdateGuestEndpoint.Route, UpdateGuestEndpoint.Handler)
            .WithMetadata(new SwaggerOperationAttribute(UpdateGuestEndpoint.Description));

        group.MapGet(GetGuestEndpoint.Route, GetGuestEndpoint.Handler)
            .WithMetadata(new SwaggerOperationAttribute(GetGuestEndpoint.Description));

        group.MapDelete(DeleteGuestEndpoint.Route, DeleteGuestEndpoint.Handler)
            .WithMetadata(new SwaggerOperationAttribute(DeleteGuestEndpoint.Description));

        group.MapPost(RsvpEndpoint.Route, RsvpEndpoint.Handler)
            .WithMetadata(new SwaggerOperationAttribute(RsvpEndpoint.Description));

        group.MapGet(AccompanyingEndpoint.Route, AccompanyingEndpoint.Handler)
            .WithMetadata(new SwaggerOperationAttribute(AccompanyingEndpoint.Description));
    }
}