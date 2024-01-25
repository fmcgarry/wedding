using MediatR;
using Microsoft.EntityFrameworkCore;
using Wedding.Core.Entities.GuestAggregate;
using Wedding.Core.Interfaces;

namespace Wedding.UseCases.Guests.Queries;

public record ListAccompanyingGuestsQuery(Guid Id) : IRequest<IEnumerable<GuestResponseModel>>;

public class ListAccompanyingGuestsHandler(IApplicationDbContext _dbContext, IEntityModelMapper<Guest, GuestResponseModel> _mapper) : IRequestHandler<ListAccompanyingGuestsQuery, IEnumerable<GuestResponseModel>>
{
    public async Task<IEnumerable<GuestResponseModel>> Handle(ListAccompanyingGuestsQuery request, CancellationToken cancellationToken)
    {
        var guests = await _dbContext.Guests.Where(guest => guest.InvitedBy.Equals(request.Id)).ToListAsync(cancellationToken);

        var response = _mapper.MapModelsFromRange(guests);

        return response;
    }
}
