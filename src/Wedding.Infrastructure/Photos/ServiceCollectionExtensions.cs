using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Wedding.Core.Interfaces;
using Wedding.Core.Services;

namespace Wedding.Infrastructure.Photos;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPhotoClient(this IServiceCollection services, IConfiguration namedConfigurationSection)
    {
        services.Configure<PhotoClientOptions>(namedConfigurationSection);

        services.AddTransient<IPhotoService, PhotoService>();
        services.AddTransient<IPhotoClient, PhotoClient>();

        return services;
    }
}
