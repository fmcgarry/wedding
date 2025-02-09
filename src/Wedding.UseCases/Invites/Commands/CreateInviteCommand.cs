using FluentResults;
using MediatR;

namespace Wedding.UseCases.Invites.Commands;

public record CreateInviteCommand(InviteModel Invite) : IRequest<Result<InviteModel>>;