using Swashbuckle.AspNetCore.Annotations;
using Wedding.Api.SongRequests.Endpoints;
using Wedding.Core.Interfaces;
using Wedding.Core.Services;

namespace Wedding.Api.SongRequests;

public class SongRequestModule : IModule
{
    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        var group = endpoints.MapGroup("/songrequests")
            .WithTags("Song Requests");

        group.MapGet("/", GetSongRequests.Handler)
            .WithMetadata(new SwaggerOperationAttribute("Gets all song requests"));

        group.MapPost("/", AddSongRequest.Handler)
            .WithMetadata(new SwaggerOperationAttribute("Add a new song request"));

        group.MapGet("/{id}", GetSongRequest.Handler)
            .WithMetadata(new SwaggerOperationAttribute("Get a specific song request"));

        group.MapPut("/{id}", UpdateSongRequest.Handler)
            .WithMetadata(new SwaggerOperationAttribute("Update a specific song request"));

        group.MapDelete("/{id}", RemoveSongRequest.Handler)
            .WithMetadata(new SwaggerOperationAttribute("Delete a specifc song request"));

        return group;
    }

    public IServiceCollection RegisterServices(IServiceCollection services)
    {
        services.AddScoped<ISongRequestService, SongRequestService>();

        return services;
    }
}
