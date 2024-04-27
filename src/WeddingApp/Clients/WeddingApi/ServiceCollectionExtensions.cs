namespace WeddingApp.Clients.WeddingApi;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddWeddingApiClient(this IServiceCollection services, IConfiguration configurationSection)
    {
        if (configurationSection.GetValue<bool>("UseFakeClient"))
        {
            services.AddSingleton<IWeddingApiClient, FakeWeddingApiClient>();
        }
        else
        {
            services.AddHttpClient<IWeddingApiClient, WeddingApiClient>(options =>
            {
                string baseAddress = configurationSection["BaseAddress"]!;
                options.BaseAddress = new Uri(baseAddress);
            });
        }

        return services;
    }
}