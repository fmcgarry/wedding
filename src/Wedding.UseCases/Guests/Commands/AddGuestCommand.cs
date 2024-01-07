using MediatR;
using Microsoft.Extensions.Logging;
using Wedding.Core.Entities.GuestAggregate;

namespace Wedding.UseCases.Guests.Commands;

public record AddGuestCommand(string Name, string Email) : IRequest<Guid>;

public class AddGuestHandler(ILogger<AddGuestCommand> _logger, IApplicationDbContext _dbContext) : IRequestHandler<AddGuestCommand, Guid>
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

        await _dbContext.Guests.AddAsync(guestModel, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return guestModel.Id;
    }
}