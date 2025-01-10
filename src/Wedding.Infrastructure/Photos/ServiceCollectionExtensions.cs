using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Wedding.Core.Photos;

namespace Wedding.Infrastructure.Photos;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddPhotoClient(this IServiceCollection services, IConfiguration namedConfigurationSection)
    {
        services.Configure<PhotoClientOptions>(namedConfigurationSection);
        services.AddTransient<IPhotoClient, PhotoClient>();

        return services;
    }
}
