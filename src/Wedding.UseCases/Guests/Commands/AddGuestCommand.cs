using MediatR;
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
}

public class AddGuestHandler(IApplicationDbContext _dbContext) : IRequestHandler<AddGuestCommand, Guid>
{
    public async Task<Guid> Handle(AddGuestCommand request, CancellationToken cancellationToken)
    {
        bool guestExists = _dbContext.Guests.Any(x => x.Email == request.Email);

        if (guestExists)
        {
            throw new InvalidOperationException($"Multiple guests with the email '{request.Email}' were found.");
        }

        var guestModel = new Guest()
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Email = request.Email,
            Phone = request.Phone,
            Address = new Address()
            {
                City = request.City,
                Line1 = request.AddressLine1,
                Id = Guid.NewGuid(),
                State = Enum.Parse<StateTerritory>(request.State, true)
            },
            DinnerSelection = Enum.Parse<FoodChoice>(request.Dinner)
        };

        await _dbContext.Guests.AddAsync(guestModel, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return guestModel.Id;
    }
}