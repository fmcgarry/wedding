using MediatR;
using Microsoft.EntityFrameworkCore;
using Wedding.Core.Entities.GuestAggregate;
using Wedding.Core.Exceptions;

namespace Wedding.UseCases.Guests.Commands;

public record RsvpCommand(Guid GuestId, FoodChoice FoodChoice) : IRequest;

public class RsvpCommandHandler(IApplicationDbContext _dbContext) : IRequestHandler<RsvpCommand>
{
    public async Task Handle(RsvpCommand request, CancellationToken cancellationToken)
    {
        var guest = await _dbContext.Guests.SingleOrDefaultAsync(g => g.Id == request.GuestId, cancellationToken) ?? throw new GuestNotFoundException(request.GuestId);

        if (guest is null)
        {
            throw new GuestNotFoundException(request.GuestId);
        }

        guest.SetAttending(request.FoodChoice);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
