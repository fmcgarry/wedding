using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Wedding.UseCases.Guests.Commands;

public record RemoveGuestCommand(Guid Id) : IRequest;

public class RemoveGuestHandler(IApplicationDbContext _dbContext) : IRequestHandler<RemoveGuestCommand>
{
    public async Task Handle(RemoveGuestCommand request, CancellationToken cancellationToken)
    {
        var guest = await _dbContext.Guests.SingleOrDefaultAsync(guest => guest.Id == request.Id, cancellationToken);

        if (guest is not null)
        {
            _dbContext.Guests.Remove(guest);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}