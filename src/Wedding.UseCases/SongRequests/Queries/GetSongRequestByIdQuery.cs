using MediatR;
using Microsoft.Extensions.Logging;

namespace Wedding.UseCases.SongRequests.Queries;

public record GetSongRequestByIdQuery(Guid Id) : IRequest<SongRequestModel>;

public class GetSongRequestByIdHandler(ILogger<GetSongRequestByIdHandler> _logger) : IRequestHandler<GetSongRequestByIdQuery, SongRequestModel>
{
    public async Task<SongRequestModel> Handle(GetSongRequestByIdQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
