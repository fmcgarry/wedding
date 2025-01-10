using MediatR;
using Wedding.Core.Guests.Entities.GuestAggregate;
using Wedding.Core.Guests.Exceptions;

namespace Wedding.UseCases.Guests.Commands;

public record AddGuestCommand(GuestModel Guest) : IRequest<Guid>;

public class AddGuestHandler(IApplicationDbContext _dbContext) : IRequestHandler<AddGuestCommand, Guid>
{
    public async Task<Guid> Handle(AddGuestCommand request, CancellationToken cancellationToken)
    {
        GuestModel guestModel = request.Guest;

        bool isDuplicateGuest = _dbContext.Guests.Any(x => x.Email == guestModel.Email);
        if (isDuplicateGuest)
        {
            throw new InvalidGuestDataException($"Multiple guests with the email '{guestModel.Email}' were found.");
        }

        if (guestModel.InvitedBy is not null)
        {
            bool isInvitedByAttendingGuest = _dbContext.Guests.Where(x => x.IsAttending).Any(x => x.Id == guestModel.InvitedBy);
            if (!isInvitedByAttendingGuest)
            {
                throw new InvalidGuestDataException("Guest was not invited by an attending guest.");
            }
        }

        var guest = new Guest()
        {
            Id = Guid.NewGuid(),
            Name = guestModel.Name,
            Email = guestModel.Email,
            Phone = guestModel.Phone,
            InvitedBy = guestModel.InvitedBy,
            Address = new()
            {
                Id = Guid.NewGuid(),
                City = guestModel.City,
                Line1 = guestModel.AddressLine1,
                Zip = guestModel.Zip
            }
        };

        if (guestModel.State is not null)
        {
            guest.Address.State = Enum.Parse<StateTerritory>(guestModel.State, true);
        }

        if (guestModel.IsAttending == true)
        {
            if (guestModel.Dinner is null)
            {
                throw new InvalidGuestDataException("Guest needs a dinner value set if attending is true.");
            }

            var dinner = Enum.Parse<FoodChoice>(guestModel.Dinner);
            guest.SetAttending(dinner);
        }

        await _dbContext.Guests.AddAsync(guest, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return guest.Id;
    }
}