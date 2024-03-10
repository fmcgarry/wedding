namespace WeddingApp.Clients.WeddingApi;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddWeddingApiClient(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHttpClient<IWeddingApiClient, WeddingApiClient>(options =>
        {
            string baseAddress = configuration["WeddingApiClient:BaseAddress"]!;
            options.BaseAddress = new Uri(baseAddress);
        });

        return services;
    }
}