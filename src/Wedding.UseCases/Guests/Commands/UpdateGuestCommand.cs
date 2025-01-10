using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;
using Wedding.Core.Common;
using Wedding.Core.Guests.Entities.GuestAggregate;
using Wedding.Core.Guests.Exceptions;

namespace Wedding.UseCases.Guests.Commands;

public record UpdateGuestCommand([property: Required] Guid Id, string? Name, [property: EmailAddress] string? Email) : IRequest;

public class UpdateGuestHandler(ILogger<UpdateGuestHandler> _logger, IApplicationDbContext _dbContext, IEntityModelMapper<Guest, GuestModel> _mapper) : IRequestHandler<UpdateGuestCommand>
{
    public async Task Handle(UpdateGuestCommand request, CancellationToken cancellationToken)
    {
        var guest = await _dbContext.Guests.SingleOrDefaultAsync(g => g.Id == request.Id, cancellationToken) ?? throw new GuestNotFoundException(request.Id);

        guest.Name = request?.Name ?? guest.Name;
        guest.Email = request?.Email ?? guest.Email;

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}