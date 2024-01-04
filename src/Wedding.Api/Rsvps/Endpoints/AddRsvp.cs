using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Wedding.Core.Entities.RsvpAggregate;
using Wedding.Core.Interfaces;
using static Wedding.Api.Rsvps.Endpoints.AddRsvp;

namespace Wedding.Api.Rsvps.Endpoints;

public class AddRsvp : Endpoint<AddRsvpRequest, AddRsvpResponse>
{
    public void Map(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("/rsvps", Handler)
            .WithMetadata(new SwaggerOperationAttribute("Add a new RSVP"));
    }

    public static async Task<Ok> Handler([FromBody] AddRsvpRequest rsvp, [FromServices] IRsvpService rsvpService)
    {
        var rsvpModel = new Rsvp()
        {

        };

        await rsvpService.AddRsvpAsync(rsvpModel);

        return TypedResults.Ok();
    }

    public override Task<AddRsvpResponse> HandleAsync(AddRsvpRequest request)
    {
        throw new NotImplementedException();
    }

    public record AddRsvpRequest() : IRequest
    {

    }

    public record AddRsvpResponse() : IResponse
    {

    }
}
