using Swashbuckle.AspNetCore.Annotations;
using Wedding.Api.Photos.Endpoints;
using Wedding.Core.Interfaces;
using Wedding.Core.Services;

namespace Wedding.Api.Photos;

public class PhotoFeature : IFeature
{
    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        var group = endpoints.MapGroup("/photos").WithTags("Photos");

        group.MapGet("/", GetPhotos.Handler)
            .WithMetadata(new SwaggerOperationAttribute("Gets all photos"));

        return endpoints;
    }

    public IServiceCollection RegisterServices(IServiceCollection services)
    {
        services.AddScoped<IPhotoService, PhotoService>();

        return services;
    }
}
