using FluentResults;
using MediatR;

namespace Wedding.UseCases.Invites.Queries;

public record ListInvitesQuery : IRequest<Result<List<InviteModel>>>;

internal class ListInvitesQueryHandler : IRequestHandler<ListInvitesQuery, Result<List<InviteModel>>>
{
    public Task<Result<List<InviteModel>>> Handle(ListInvitesQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}