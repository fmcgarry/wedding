namespace Wedding.Api;

public abstract class Endpoint<IRequest, IResponse>
{
    public abstract Task<IResponse> HandleAsync(IRequest request);
}

public abstract class Endpoint<IResponse>
{
    public abstract Task<IResponse> HandleAsync<IRequest>(IRequest response);
}