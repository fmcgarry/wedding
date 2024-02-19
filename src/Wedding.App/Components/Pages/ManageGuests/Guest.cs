namespace Wedding.App.Components.Pages.ManageGuests;

public class Guest
{
    public enum RsvpState
    {
        Pending,
        Attending,
        Declined
    }

    public string Name { get; set; } = string.Empty;
    public RsvpState Rsvp { get; set; }
    public string InvitedBy { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Dinner { get; set; } = string.Empty;
}