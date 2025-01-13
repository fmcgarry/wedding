namespace WeddingApp.Clients.WeddingApi;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddWeddingApiClient(this IServiceCollection services, IConfiguration configuration)
    {

        if (configuration.GetValue<bool>("WeddingApiClient:IsSimulated"))
        {
            services.AddScoped<IWeddingApiClient, FakeWeddingApiClient>();
        }
        else
        {
            services.AddHttpClient<IWeddingApiClient, WeddingApiClient>(options =>
            {
                string baseAddress = configuration["WeddingApiClient:BaseAddress"] ?? throw new InvalidOperationException("WeddingApiClient BaseAddress is not set");
                options.BaseAddress = new Uri(baseAddress);
            });
        }

        return services;
    }
}