using MediatR;
using Microsoft.AspNetCore.Mvc;
using Wedding.UseCases.Invites;
using Wedding.UseCases.Invites.Commands;
using Wedding.UseCases.Invites.Queries;

namespace Wedding.Api.Invites;

/// <summary>
/// This controller demonstrates the classic design, where the controller is a class.
/// </summary>
[Route("[controller]")]
[ApiController]
public class InvitesController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateInvite([FromBody] InviteModel invite)
    {
        var result = await mediator.Send(new CreateInviteCommand(invite));

        if (result.IsFailed)
        {
            return BadRequest(result.Errors);
        }

        return CreatedAtAction(nameof(GetInvites), new { id = invite.Id }, invite);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteInvite(Guid id)
    {
        var result = await mediator.Send(new DeleteInviteByIdCommand(id));

        if (result.IsFailed)
        {
            return BadRequest(result.Errors);
        }

        return NoContent();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetInviteById(Guid id)
    {
        var result = await mediator.Send(new GetInviteByIdQuery(id));

        if (result.IsFailed)
        {
            return BadRequest(result.Reasons);
        }

        if (result.Value is null)
        {
            return NotFound();
        }

        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetInvites()
    {
        var result = await mediator.Send(new ListInvitesQuery());

        if (result.IsFailed)
        {
            return BadRequest(result.Errors);
        }

        return Ok(result.Value);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateInvite(Guid id, [FromBody] InviteModel updatedInvite)
    {
        var result = await mediator.Send(new UpdateInviteCommand(id, updatedInvite.InvitedGuests, updatedInvite.ConfirmedGuests));

        if (result.IsFailed)
        {
            return BadRequest(result.Errors);
        }

        return NoContent();
    }
}