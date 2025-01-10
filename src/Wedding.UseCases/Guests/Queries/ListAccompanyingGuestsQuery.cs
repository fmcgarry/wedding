using MediatR;
using Microsoft.EntityFrameworkCore;
using Wedding.Core.Common;
using Wedding.Core.Guests.Entities.GuestAggregate;

namespace Wedding.UseCases.Guests.Queries;

public record ListAccompanyingGuestsQuery(Guid Id) : IRequest<IEnumerable<GuestModel>>;

public class ListAccompanyingGuestsHandler(IApplicationDbContext _dbContext, IEntityModelMapper<Guest, GuestModel> _mapper) : IRequestHandler<ListAccompanyingGuestsQuery, IEnumerable<GuestModel>>
{
    public async Task<IEnumerable<GuestModel>> Handle(ListAccompanyingGuestsQuery request, CancellationToken cancellationToken)
    {
        var guests = await _dbContext.Guests
            .Include(guest => guest.Address)
            .Where(guest => guest.InvitedBy.Equals(request.Id))
            .ToListAsync(cancellationToken);

        var response = _mapper.MapModelsFromRange(guests);

        return response;
    }
}
