using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Wedding.Core.Common;
using Wedding.Core.Guests.Entities.GuestAggregate;
using Wedding.Core.Photos;
using Wedding.Core.SongRequests;
using Wedding.UseCases.Guests;
using Wedding.UseCases.Photos;
using Wedding.UseCases.SongRequests;

namespace Wedding.UseCases;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddUseCasesServices(this IServiceCollection services)
    {
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });

        services.AddScoped<IEntityModelMapper<Guest, GuestModel>, GuestMapper>();
        services.AddScoped<IEntityModelMapper<Photo, PhotoModel>, PhotoMapper>();
        services.AddScoped<IEntityModelMapper<SongRequest, SongRequestModel>, SongRequestMapper>();

        return services;
    }
}