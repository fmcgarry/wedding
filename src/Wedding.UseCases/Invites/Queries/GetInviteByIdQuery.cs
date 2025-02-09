using FluentResults;
using MediatR;

namespace Wedding.UseCases.Invites.Queries;

public record GetInviteByIdQuery(Guid Id) : IRequest<Result<InviteModel>>;

internal class GetInviteByIdQueryHandler : IRequestHandler<GetInviteByIdQuery, Result<InviteModel>>
{
    public Task<Result<InviteModel>> Handle(GetInviteByIdQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}