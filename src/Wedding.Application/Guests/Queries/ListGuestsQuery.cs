using MediatR;
using Microsoft.Extensions.Logging;
using Wedding.Core.Entities;
using Wedding.Core.Interfaces;

namespace Wedding.UseCases.Guests.Queries;

public record ListGuestsQuery() : IRequest<IEnumerable<GuestModel>>;

public class ListGuestsHandler(ILogger<ListGuestsHandler> logger, IGuestService guestService, IEntityModelMapper<Guest, GuestModel> _mapper)
    : IRequestHandler<ListGuestsQuery, IEnumerable<GuestModel>>
{
    private readonly ILogger<ListGuestsHandler> _logger = logger;
    private readonly IGuestService _guestService = guestService;

    public async Task<IEnumerable<GuestModel>> Handle(ListGuestsQuery request, CancellationToken cancellationToken)
    {
        _logger.LogTrace($"made it to {nameof(ListGuestsHandler)}");

        var results = new List<GuestModel>();

        var guests = await _guestService.GetGuestsAsync();

        foreach (var guest in guests)
        {
            var result = _mapper.MapModelFrom(guest);
            results.Add(result);
        }

        return results;
    }
}