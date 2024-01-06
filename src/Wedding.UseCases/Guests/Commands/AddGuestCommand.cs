using MediatR;
using Microsoft.Extensions.Logging;
using Wedding.Core.Entities.GuestAggregate;
using Wedding.Core.Interfaces;

namespace Wedding.UseCases.Guests.Commands;

public record AddGuestCommand(string Name, string Email) : IRequest<Guid>;

public class AddGuestHandler(ILogger<AddGuestCommand> _logger, IGuestService _guestService) : IRequestHandler<AddGuestCommand, Guid>
{
    public async Task<Guid> Handle(AddGuestCommand request, CancellationToken cancellationToken)
    {
        _logger.LogTrace($"made it to {nameof(AddGuestCommand)}");

        var guestModel = new Guest()
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Email = request.Email,
        };

        await _guestService.AddGuestAsync(guestModel);

        return guestModel.Id;
    }
}