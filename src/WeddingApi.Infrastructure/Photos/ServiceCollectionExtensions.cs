using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WeddingApi.Core.Interfaces;
using WeddingApi.Core.Services;

namespace WeddingApi.Infrastructure.Photos;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPhotoClient(this IServiceCollection services, IConfiguration namedConfigurationSection)
    {
        services.AddTransient<IPhotoService, PhotoService>();
        services.AddTransient<IPhotoClient, PhotoClient>();

        return services;
    }
}
