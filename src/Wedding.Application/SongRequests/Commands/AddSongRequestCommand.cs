using MediatR;

namespace Wedding.UseCases.SongRequests.Commands;

public record AddSongRequestCommand(SongRequestModel SongRequest) : IRequest;

public class AddSongRequestHandler : IRequestHandler<AddSongRequestCommand>
{
    public async Task Handle(AddSongRequestCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
