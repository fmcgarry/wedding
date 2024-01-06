using MediatR;

namespace Wedding.UseCases.Guests.Queries;

public record ListAttendingGuestsQuery : IRequest<IEnumerable<GuestModel>>;

public class ListAttendingGuestsHandler : IRequestHandler<ListAttendingGuestsQuery, IEnumerable<GuestModel>>
{
    public Task<IEnumerable<GuestModel>> Handle(ListAttendingGuestsQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}