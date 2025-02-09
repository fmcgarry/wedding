namespace Wedding.UseCases.Invites;

public class InviteModel
{
    public List<string> ConfirmedGuests { get; set; } = [];
    public Guid? Id { get; set; }
    public List<string> InvitedGuests { get; set; } = [];
}