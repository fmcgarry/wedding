using Microsoft.AspNetCore.Components;
using Wedding.App.Clients.WeddingApi;

namespace Wedding.App.Components.Pages.Rsvp;

public partial class RsvpPage
{
    private bool? _isAttending = null;

    [Inject]
    private ILogger<RsvpPage> Logger { get; init; } = default!;

    [Inject]
    private IWeddingApiClient WeddingApiClient { get; init; } = default!;

    [SupplyParameterFromForm]
    private RsvpModel Rsvp { get; set; } = new();

    private async Task Submit()
    {
        Logger.LogDebug("Submit button pressed");
        await WeddingApiClient.SendRsvpAsync(Rsvp);
    }
}