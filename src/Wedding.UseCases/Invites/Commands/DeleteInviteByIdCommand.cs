using FluentResults;
using MediatR;

namespace Wedding.UseCases.Invites.Commands;

public record DeleteInviteByIdCommand(Guid Id) : IRequest<Result>;

internal class DeleteInviteByIdCommandHandler : IRequestHandler<DeleteInviteByIdCommand, Result>
{
    public Task<Result> Handle(DeleteInviteByIdCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}