using MediatR;
using Microsoft.Extensions.Logging;
using Wedding.Core.Entities.GuestAggregate;
using Wedding.Core.Interfaces;

namespace Wedding.UseCases.Guests.Queries;

public record GetGuestbyIdQuery(Guid Id) : IRequest<GuestModel?>;

public class GetGuestHandler(ILogger<GetGuestHandler> _logger, IGuestService _guestService, IEntityModelMapper<Guest, GuestModel> _mapper) : IRequestHandler<GetGuestbyIdQuery, GuestModel?>
{
    public async Task<GuestModel?> Handle(GetGuestbyIdQuery request, CancellationToken cancellationToken)
    {
        _logger.LogTrace($"made it to {nameof(GetGuestHandler)}");

        var guest = await _guestService.GetGuestByIdAsync(request.Id);

        if (guest is null)
        {
            return null;
        }

        var result = _mapper.MapModelFrom(guest);

        return result;
    }
}