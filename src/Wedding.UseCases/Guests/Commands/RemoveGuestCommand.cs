using MediatR;
using Wedding.Core.Interfaces;

namespace Wedding.UseCases.Guests.Commands;

public record RemoveGuestCommand(Guid Id) : IRequest;

public class RemoveGuestHandler(IGuestService _guestService) : IRequestHandler<RemoveGuestCommand>
{
    public async Task Handle(RemoveGuestCommand request, CancellationToken cancellationToken)
    {
        var guest = await _guestService.GetGuestByIdAsync(request.Id);

        if (guest is not null)
        {
            await _guestService.RemoveGuestAsync(guest.Id);
        }
    }
}

