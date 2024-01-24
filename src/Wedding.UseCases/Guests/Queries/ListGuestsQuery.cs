using MediatR;
using Wedding.Core.Entities.GuestAggregate;
using Wedding.Core.Interfaces;

namespace Wedding.UseCases.Guests.Queries;

public record ListGuestsQuery() : IRequest<IEnumerable<GuestResponseModel>>;

public class ListGuestsHandler(IApplicationDbContext _dbContext, IEntityModelMapper<Guest, GuestResponseModel> _mapper)
    : IRequestHandler<ListGuestsQuery, IEnumerable<GuestResponseModel>>
{
    public Task<IEnumerable<GuestResponseModel>> Handle(ListGuestsQuery request, CancellationToken cancellationToken)
    {
        var guests = _mapper.MapModelsFromRange(_dbContext.Guests);

        return Task.FromResult(guests);
    }
}