using MediatR;
using Microsoft.EntityFrameworkCore;
using Wedding.Core.Entities.GuestAggregate;
using Wedding.Core.Interfaces;

namespace Wedding.UseCases.Guests.Queries;

public record ListGuestsQuery() : IRequest<IEnumerable<GuestModel>>;

public class ListGuestsHandler(IApplicationDbContext _dbContext, IEntityModelMapper<Guest, GuestModel> _mapper)
    : IRequestHandler<ListGuestsQuery, IEnumerable<GuestModel>>
{
    public Task<IEnumerable<GuestModel>> Handle(ListGuestsQuery request, CancellationToken cancellationToken)
    {
        var guests = _mapper.MapModelsFromRange(_dbContext.Guests.Include(guest => guest.Address));

        return Task.FromResult(guests);
    }
}