using Swashbuckle.AspNetCore.Annotations;
using Wedding.Api.Photos.Endpoints;
using Wedding.Infrastructure.Photos;

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

    public IServiceCollection RegisterServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddPhotoClient(configuration.GetRequiredSection(nameof(PhotoFeature)));

        return services;
    }
}
