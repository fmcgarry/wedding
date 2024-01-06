using MediatR;

namespace Wedding.UseCases.SongRequests.Commands;

public record UpdateSongRequestCommand : IRequest;

public class UpdateSongRequestHandler : IRequestHandler<UpdateSongRequestCommand>
{
    public async Task Handle(UpdateSongRequestCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
