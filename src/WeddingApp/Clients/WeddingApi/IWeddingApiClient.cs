using WeddingApp.Components.Pages.Rsvp;

namespace WeddingApp.Clients.WeddingApi;

public interface IWeddingApiClient
{
    Task SendRsvpAsync(RsvpModel rsvp);
}