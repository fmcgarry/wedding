using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WeddingApi.Core.Entities.RsvpAggregate;
using WeddingApi.Core.Interfaces;
using static WeddingApi.Rsvps.Endpoints.AddRsvp;

namespace WeddingApi.Rsvps.Endpoints;

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
