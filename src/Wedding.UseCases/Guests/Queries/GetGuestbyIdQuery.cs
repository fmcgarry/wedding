using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Wedding.Core.Entities.GuestAggregate;
using Wedding.Core.Exceptions;
using Wedding.Core.Interfaces;

namespace Wedding.UseCases.Guests.Queries;

public record GetGuestbyIdQuery(Guid Id) : IRequest<GuestModel>;

public class GetGuestHandler(ILogger<GetGuestHandler> _logger, IApplicationDbContext _dbContext, IEntityModelMapper<Guest, GuestModel> _mapper) : IRequestHandler<GetGuestbyIdQuery, GuestModel>
{
    public async Task<GuestModel> Handle(GetGuestbyIdQuery request, CancellationToken cancellationToken)
    {
        var guest = await _dbContext.Guests.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (guest is null)
        {
            _logger.LogWarning("Could not find a guest with id: {id}.", request.Id);
            throw new GuestNotFoundException(request.Id);
        }

        var result = _mapper.MapModelFrom(guest);

        return result;
    }
}