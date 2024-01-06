using MediatR;
using Microsoft.Extensions.Logging;
using Wedding.Core.Entities.GuestAggregate;
using Wedding.Core.Interfaces;

namespace Wedding.UseCases.Guests.Commands;

public record UpdateGuestInfoCommand(Guid Id, GuestModel Guest) : IRequest;

public class UpdateGuestInfoHandler(ILogger<UpdateGuestInfoHandler> _logger, IGuestService _guestService, IEntityModelMapper<Guest, GuestModel> _mapper) : IRequestHandler<UpdateGuestInfoCommand>
{
    public async Task Handle(UpdateGuestInfoCommand request, CancellationToken cancellationToken)
    {
        _logger.LogTrace($"made it to {nameof(UpdateGuestInfoHandler)}");

        var guest = _mapper.MapEntityFrom(request.Guest);
        await _guestService.UpdateGuestAsync(request.Id, guest);
    }
}