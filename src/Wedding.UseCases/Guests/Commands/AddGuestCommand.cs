﻿using MediatR;
using System.ComponentModel.DataAnnotations;
using Wedding.Core.Entities.GuestAggregate;

namespace Wedding.UseCases.Guests.Commands;

public record AddGuestCommand([property: Required] string Name, [property: EmailAddress] string? Email) : IRequest<Guid>;

public class AddGuestHandler(IApplicationDbContext _dbContext) : IRequestHandler<AddGuestCommand, Guid>
{
    public async Task<Guid> Handle(AddGuestCommand request, CancellationToken cancellationToken)
    {
        var guestModel = new Guest()
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Email = request.Email
        };

        await _dbContext.Guests.AddAsync(guestModel, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return guestModel.Id;
    }
}