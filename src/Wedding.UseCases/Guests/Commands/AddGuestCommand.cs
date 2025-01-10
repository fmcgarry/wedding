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
            throw new InvalidGuestDataException($"Multiple guests with the email '{guestModel.Email}' were found. Only one guest per email is permitted.");
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
            bool isValidState = Enum.TryParse(guestModel.State, true, out StateTerritory state);
            if (!isValidState)
            {
                throw new InvalidGuestDataException($"An invalid state '{guestModel.State}' was provided.  Value must be one of: {string.Join("|", Enum.GetValues<StateTerritory>())}");
            }

            guest.Address.State = state;
        }

        if (guestModel.IsAttending == true)
        {
            if (guestModel.Dinner is null)
            {
                throw new InvalidGuestDataException($"Guest needs a valid dinner value set if they are attending. Value must be one of: {string.Join("|", Enum.GetValues<FoodChoice>())}.");
            }

            var isValidDinner = Enum.TryParse(guestModel.Dinner, true, out FoodChoice dinner);
            if (!isValidDinner)
            {
                throw new InvalidGuestDataException($"An invalid dinner '{guestModel.Dinner}' was provided. Value must be one of: {string.Join("|", Enum.GetValues<FoodChoice>())}.");
            }

            guest.SetAttending(dinner);
        }

        await _dbContext.Guests.AddAsync(guest, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return guest.Id;
    }
}