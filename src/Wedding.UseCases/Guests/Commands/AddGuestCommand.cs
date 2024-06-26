﻿using MediatR;
using System.ComponentModel.DataAnnotations;
using Wedding.Core.Entities.GuestAggregate;

namespace Wedding.UseCases.Guests.Commands;

public class AddGuestCommand : IRequest<Guid>
{
    public string? AddressLine1 { get; init; }

    public string? City { get; init; }

    public string? Dinner { get; init; }

    [EmailAddress]
    public string? Email { get; init; }

    [Required]
    public required string Name { get; init; }

    [Phone]
    public string? Phone { get; init; }

    public string? State { get; init; }

    [StringLength(5, MinimumLength = 5)]
    public string? Zip { get; init; }

    public Guid? InvitedBy { get; set; }

    public bool? IsAttending { get; set; }
}

public class AddGuestHandler(IApplicationDbContext _dbContext) : IRequestHandler<AddGuestCommand, Guid>
{
    public async Task<Guid> Handle(AddGuestCommand request, CancellationToken cancellationToken)
    {
        bool isDuplicateGuest = _dbContext.Guests.Any(x => x.Email == request.Email);
        if (isDuplicateGuest)
        {
            throw new InvalidOperationException($"Multiple guests with the email '{request.Email}' were found.");
        }

        if (request.InvitedBy is not null)
        {
            bool isInvitedByAttendingGuest = _dbContext.Guests.Where(x => x.IsAttending).Any(x => x.Id == request.InvitedBy);
            if (!isInvitedByAttendingGuest)
            {
                throw new InvalidOperationException("Guest was not invited by an attending guest.");
            }
        }

        var guest = new Guest()
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Email = request.Email,
            Phone = request.Phone,
            Address = new Address()
            {
                Id = Guid.NewGuid(),
                City = request.City,
                Line1 = request.AddressLine1
            },
            InvitedBy = request.InvitedBy
        };

        if (request.State is not null)
        {
            guest.Address.State = Enum.Parse<StateTerritory>(request.State, true);
        }

        if (request.IsAttending == true)
        {
            if (request.Dinner is null)
            {
                throw new InvalidOperationException("Guest needs a dinner set if attending.");
            }

            var dinner = Enum.Parse<FoodChoice>(request.Dinner);
            guest.SetAttending(dinner);
        }

        await _dbContext.Guests.AddAsync(guest, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return guest.Id;
    }
}