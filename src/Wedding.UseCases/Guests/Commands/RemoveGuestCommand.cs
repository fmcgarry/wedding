using MediatR;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Wedding.UseCases.Guests.Commands;

public record RemoveGuestCommand([property: Required] Guid Id) : IRequest;

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