using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Wedding.Core.Entities;
using Wedding.Core.Interfaces;
using Wedding.Core.Services;
using Wedding.UseCases.Guests;
using Wedding.UseCases.Photos;
using Wedding.UseCases.SongRequests;

namespace Wedding.UseCases;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });

        services.AddScoped<IGuestService, GuestService>();
        services.AddScoped<IEntityModelMapper<Guest, GuestModel>, GuestMapper>();

        services.AddScoped<IPhotoService, PhotoService>();
        services.AddScoped<IEntityModelMapper<Photo, PhotoModel>, PhotoMapper>();

        services.AddScoped<ISongRequestService, SongRequestService>();
        services.AddScoped<IEntityModelMapper<SongRequest, SongRequestModel>, SongRequestMapper>();

        return services;
    }
}
