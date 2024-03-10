using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.QuickGrid;
using Microsoft.AspNetCore.Components.Web;
using WeddingApp.Clients.WeddingApi;
using WeddingApp.Clients.WeddingApi.Models;

namespace WeddingApp.Components.Pages.ManageGuests;

public partial class ManageGuestsPage
{
    private readonly PaginationState _guestsTablePagination = new() { ItemsPerPage = 10 };
    private IQueryable<Guest>? _guests;

    [Inject]
    public required IWeddingApiClient WeddingApiClient { get; init; }

    protected override async Task OnInitializedAsync()
    {
        var list = new List<Guest>()
        {
            new() { Name = "Taco McGinnen", Rsvp = Guest.RsvpState.Attending },
            new() { Name = "Meatloaf Sunny", Rsvp = Guest.RsvpState.Attending, InvitedBy = "Ash Ketchum", Address = "123 Oak Street, Pallet Town, PA 12345", Phone = "814-867-5309", Dinner = "Meatloaf" },
            new() { Name = "Tomato Souper" },
            new() { Name = "Cheezy McGee" },
            new() { Name = "Burrito Tyler", Rsvp = Guest.RsvpState.Attending },
            new() { Name = "Sausage Smith" },
            new() { Name = "Potato Tater", Rsvp = Guest.RsvpState.Declined },
            new() { Name = "Ramen Namuri" },
        };

        var guests = await WeddingApiClient.GetAllGuestsAsync();

        _guests = guests?.AsQueryable();
    }

    private void AddGuest(MouseEventArgs e)
    {
    }

    private void DeleteGuest(Guest guest)
    {
    }

    private void EditGuest(Guest guest)
    {
    }
}