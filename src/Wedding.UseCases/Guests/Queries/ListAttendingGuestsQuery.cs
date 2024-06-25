using MediatR;
using Microsoft.EntityFrameworkCore;
using Wedding.Core.Entities.GuestAggregate;
using Wedding.Core.Interfaces;

namespace Wedding.UseCases.Guests.Queries;

public record ListAttendingGuestsQuery : IRequest<IEnumerable<GuestResponseModel>>;

public class ListAttendingGuestsHandler(IApplicationDbContext _dbContext, IEntityModelMapper<Guest, GuestResponseModel> _mapper)
    : IRequestHandler<ListAttendingGuestsQuery, IEnumerable<GuestResponseModel>>
{
    public Task<IEnumerable<GuestResponseModel>> Handle(ListAttendingGuestsQuery request, CancellationToken cancellationToken)
    {
        var attendingGuests = _dbContext.Guests
            .Include(guest => guest.Address)
            .Where(guest => guest.IsAttending);

        var attendingGuestModels = _mapper.MapModelsFromRange(attendingGuests);

        return Task.FromResult(attendingGuestModels);
    }
}