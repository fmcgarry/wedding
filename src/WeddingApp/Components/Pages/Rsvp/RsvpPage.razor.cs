using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using WeddingApp.Clients.WeddingApi;
using WeddingApp.Components.Forms;

namespace WeddingApp.Components.Pages.Rsvp;

public partial class RsvpPage
{
    private readonly List<string> _states = ["PA", "NC"];
    private EditContext? _addressFormEditContext;
    private bool? _isAttending = null;

    private bool _isFirstPage = true;
    private EditContext? _rsvpFormEditContext;

    [SupplyParameterFromForm(FormName = "AddressForm")]
    private AddressModel Address { get; set; } = new();

    [Inject]
    private ILogger<RsvpPage> Logger { get; init; } = default!;

    [SupplyParameterFromForm(FormName = "RsvpForm")]
    private RsvpModel Rsvp { get; set; } = new();

    [Inject]
    private IWeddingApiClient WeddingApiClient { get; init; } = default!;

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
    }

    private void SubmitAddress()
    {
        Logger.LogDebug("Submit address button pressed");
        _isFirstPage = false;
    }
}