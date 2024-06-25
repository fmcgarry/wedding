using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
            if (configuration.GetValue<bool>("UseInMemoryDb"))
            {
                options.UseInMemoryDatabase("wedding");
            }
            else
            {
                string? connectionString = configuration.GetConnectionString("ApplicationDb");
                options.UseSqlServer(connectionString);
            }
        });

        services.AddPhotoClient(configuration.GetSection(PhotoClientOptions.PhotoClient));

        return services;
    }
}