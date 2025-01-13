using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using WeddingApp.Clients.WeddingApi;
using WeddingApp.Clients.WeddingApi.Models;
using WeddingApp.Components.Forms;

namespace WeddingApp.Components.Pages.Rsvp;

public partial class RsvpPage
{
    private EditContext? _addressFormEditContext;
    private bool? _isAttending = null;
    private EditContext? _rsvpFormEditContext;
    private Page _currentPage;

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

    private void SubmitAddress()
    {
        Logger.LogDebug("Submit address button pressed");
        _currentPage = Page.DinnerDetails;
    }

    private void SubmitDinnerDetails()
    {
        Logger.LogDebug("Submit additional details button pressed");
        _currentPage = Page.AdditionalGuests;
    }

    private void SubmitAdditionalGuests()
    {
        Logger.LogDebug("Submit additional details button pressed");
        _currentPage = Page.AdditionalGuests;
    }

    private async Task SubmitConfirmation()
    {
        Logger.LogDebug("Submit confirmation button pressed");

        var guest = new Guest()
        {
            Name = Address.Name,
            Address = Address.Address,
            Dinner = Rsvp.DinnerSelection.ToString(),
            Phone = Address.Phone,
            Rsvp = Guest.RsvpState.Attending
        };

        await WeddingApiClient.AddGuestAsync(guest);
    }

    private enum Page
    {
        Address,
        DinnerDetails,
        AdditionalGuests,
        Confirmation
    }
}