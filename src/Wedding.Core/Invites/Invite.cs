using Wedding.Core.Common;

namespace Wedding.Core.Invites;

public class Invite : IEntity
{
    public List<string> ConfirmedGuests { get; set; } = [];
    public Guid Id { get; set; }
    public List<string> InvitedGuests { get; set; } = [];
    public DateTime LastEditDate { get; set; }
    public DateTime LastLoginDate { get; set; }
    public string PasswordKeyHash { get; set; } = string.Empty;
}