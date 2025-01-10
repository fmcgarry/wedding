using MediatR;
using Microsoft.EntityFrameworkCore;
using Wedding.Core.Common;
using Wedding.Core.Guests.Entities.GuestAggregate;

namespace Wedding.UseCases.Guests.Queries;

public record ListAttendingGuestsQuery : IRequest<IEnumerable<GuestModel>>;

public class ListAttendingGuestsHandler(IApplicationDbContext _dbContext, IEntityModelMapper<Guest, GuestModel> _mapper)
    : IRequestHandler<ListAttendingGuestsQuery, IEnumerable<GuestModel>>
{
    public Task<IEnumerable<GuestModel>> Handle(ListAttendingGuestsQuery request, CancellationToken cancellationToken)
    {
        var attendingGuests = _dbContext.Guests
            .Include(guest => guest.Address)
            .Where(guest => guest.IsAttending);

        var attendingGuestModels = _mapper.MapModelsFromRange(attendingGuests);

        return Task.FromResult(attendingGuestModels);
    }
}