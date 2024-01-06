using MediatR;
using Microsoft.Extensions.Logging;
using Wedding.Core.Entities;
using Wedding.Core.Interfaces;

namespace Wedding.UseCases.Guests.Commands;

public record UpdateGuestCommand(Guid Id, GuestModel Guest) : IRequest;

public class UpdateGuestHandler(ILogger<UpdateGuestHandler> _logger, IGuestService _guestService, IEntityModelMapper<Guest, GuestModel> _mapper) : IRequestHandler<UpdateGuestCommand>
{
    public async Task Handle(UpdateGuestCommand request, CancellationToken cancellationToken)
    {
        _logger.LogTrace($"made it to {nameof(UpdateGuestHandler)}");

        var guest = _mapper.MapEntityFrom(request.Guest);
        await _guestService.UpdateGuestAsync(request.Id, guest);
    }
}