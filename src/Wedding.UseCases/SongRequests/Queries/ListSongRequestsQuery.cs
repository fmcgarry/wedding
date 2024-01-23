using MediatR;
using Microsoft.Extensions.Logging;

namespace Wedding.UseCases.SongRequests.Queries;

public record ListSongRequestsQuery : IRequest<IEnumerable<SongRequestModel>>;

public class ListSongRequestsHandler(ILogger<ListSongRequestsHandler> _logger) : IRequestHandler<ListSongRequestsQuery, IEnumerable<SongRequestModel>>
{
    public async Task<IEnumerable<SongRequestModel>> Handle(ListSongRequestsQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}