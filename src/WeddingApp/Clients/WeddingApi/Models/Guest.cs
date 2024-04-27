namespace WeddingApp.Clients.WeddingApi.Models;

public class Guest
{
    public enum RsvpState
    {
        Requested,
        Attending,
        Declined
    }

    public string Address { get; set; } = string.Empty;
    public string Dinner { get; set; } = string.Empty;
    public string InvitedBy { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public RsvpState Rsvp { get; set; }
}