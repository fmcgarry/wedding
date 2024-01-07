using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Wedding.Core.Entities.GuestAggregate;
using Wedding.Core.Interfaces;

namespace Wedding.UseCases.Guests.Commands;

public record UpdateGuestInfoCommand(Guid Id, GuestModel Guest) : IRequest;

public class UpdateGuestInfoHandler(ILogger<UpdateGuestInfoHandler> _logger, IApplicationDbContext _dbContext, IEntityModelMapper<Guest, GuestModel> _mapper)
    : IRequestHandler<UpdateGuestInfoCommand>
{
    public async Task Handle(UpdateGuestInfoCommand request, CancellationToken cancellationToken)
    {
        var guest = await _dbContext.Guests.SingleOrDefaultAsync(g => g.Id == request.Id, cancellationToken);

        if (guest is null)
        {
            _logger.LogWarning("Could not find a guest with id: {id}", request.Id);
            return;
        }

        guest.Name = request.Guest.Name;
        guest.Email = request.Guest.Email;

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}