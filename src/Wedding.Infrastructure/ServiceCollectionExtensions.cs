using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Wedding.Core.Interfaces;
using Wedding.Infrastructure.Data;
using Wedding.Infrastructure.Photos;
using Wedding.UseCases;

namespace Wedding.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<IApplicationDbContext, ApplicationDbContext>(options =>
        {
            string? connectionString = configuration.GetConnectionString("ApplicationDb");
            options.UseSqlServer(connectionString);
        });

        services.AddScoped<IPhotoClient, PhotoClient>();

        return services;
    }
}