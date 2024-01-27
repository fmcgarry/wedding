using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Wedding.App.Clients.WeddingApi;
using Wedding.App.Components.Forms;

namespace Wedding.App.Components.Pages.Rsvp;

public partial class RsvpPage
{
    private bool? _isAttending = null;

    private bool _isFirstPage = true;

    private readonly List<string> _states = ["PA", "NC"];

    private EditContext? _addressFormEditContext;
    private EditContext? _rsvpFormEditContext;

    [Inject]
    private ILogger<RsvpPage> Logger { get; init; } = default!;

    [Inject]
    private IWeddingApiClient WeddingApiClient { get; init; } = default!;

    [SupplyParameterFromForm(FormName = "RsvpForm")]
    private RsvpModel Rsvp { get; set; } = new();

    [SupplyParameterFromForm(FormName = "AddressForm")]
    private AddressModel Address { get; set; } = new();

    protected override void OnInitialized()
    {
        _addressFormEditContext = new(Address);
        _rsvpFormEditContext = new(Rsvp);
        _addressFormEditContext.SetFieldCssClassProvider(new BootstrapValidationFieldClassProvider());
        _rsvpFormEditContext.SetFieldCssClassProvider(new BootstrapValidationFieldClassProvider());
    }

    private async Task Submit()
    {
        Logger.LogDebug("Submit button pressed");
        await WeddingApiClient.SendRsvpAsync(Rsvp);
    }

    private void SubmitAddress()
    {
        Logger.LogDebug("Submit address button pressed");
        _isFirstPage = false;
    }
}