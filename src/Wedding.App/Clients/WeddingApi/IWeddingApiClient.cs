using Wedding.App.Components.Pages.Rsvp;

namespace Wedding.App.Clients.WeddingApi;

public interface IWeddingApiClient
{
    Task SendRsvpAsync(RsvpModel rsvp);
}