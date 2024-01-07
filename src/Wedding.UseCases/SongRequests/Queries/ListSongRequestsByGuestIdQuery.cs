using MediatR;
using Microsoft.Extensions.Logging;

namespace Wedding.UseCases.SongRequests.Queries;

public record ListSongRequestsByGuestIdQuery(Guid GuestId) : IRequest<IEnumerable<SongRequestModel>>;

public class ListSongRequestsByGuestIdHandler(ILogger<ListSongRequestsByGuestIdHandler> _logger, IApplicationDbContext _dbContext)
    : IRequestHandler<ListSongRequestsByGuestIdQuery, IEnumerable<SongRequestModel>>
{
    public Task<IEnumerable<SongRequestModel>> Handle(ListSongRequestsByGuestIdQuery request, CancellationToken cancellationToken)
    {
        _logger.LogTrace("here");
        throw new NotImplementedException();
    }
}