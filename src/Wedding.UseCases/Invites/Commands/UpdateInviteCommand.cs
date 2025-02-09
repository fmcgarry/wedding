using FluentResults;
using MediatR;

namespace Wedding.UseCases.Invites.Commands;

public record UpdateInviteCommand(Guid Id, IEnumerable<string> Invited, IEnumerable<string> Confirmed) : IRequest<Result<InviteModel>>;

internal class UpdateInviteCommandHandler : IRequestHandler<UpdateInviteCommand, Result<InviteModel>>
{
    public Task<Result<InviteModel>> Handle(UpdateInviteCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}