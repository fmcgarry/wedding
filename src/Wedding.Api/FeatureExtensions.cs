namespace Wedding.Api;

public static class FeatureExtensions
{
    // this could also be added into the DI container
    static readonly List<IFeature> registeredFeatures = new();

    public static IServiceCollection RegisterFeatureServices(this IServiceCollection services)
    {
        var features = DiscoverFeatures();
        foreach (var feature in features)
        {
            feature.RegisterServices(services);
            registeredFeatures.Add(feature);
        }

        return services;
    }

    public static WebApplication MapFeatureEndpoints(this WebApplication app)
    {
        foreach (var feature in registeredFeatures)
        {
            feature.MapEndpoints(app);
        }

        return app;
    }

    private static IEnumerable<IFeature> DiscoverFeatures()
    {
        return typeof(IFeature).Assembly
            .GetTypes()
            .Where(p => p.IsClass && p.IsAssignableTo(typeof(IFeature)))
            .Select(Activator.CreateInstance)
            .Cast<IFeature>();
    }
}
