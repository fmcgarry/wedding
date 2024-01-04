namespace Wedding.Api;

public interface IFeature
{
    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints);
    public IServiceCollection RegisterServices(IServiceCollection services, IConfiguration configuration);
}
