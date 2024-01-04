namespace WeddingApi;

public interface IModule
{
    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints);
    public IServiceCollection RegisterServices(IServiceCollection services);
}
