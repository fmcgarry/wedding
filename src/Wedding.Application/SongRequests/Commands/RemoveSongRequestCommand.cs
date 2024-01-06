using MediatR;

namespace Wedding.UseCases.SongRequests.Commands;

public record RemoveSongRequestCommand(Guid Id) : IRequest;

public class RemoveSongRequestHandler : IRequestHandler<RemoveSongRequestCommand>
{
    public async Task Handle(RemoveSongRequestCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
