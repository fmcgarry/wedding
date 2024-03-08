using Microsoft.AspNetCore.Components.QuickGrid;
using Microsoft.AspNetCore.Components.Web;

namespace WeddingApp.Components.Pages.ManageGuests;

public partial class ManageGuestsPage
{
    private IQueryable<Guest>? _guests;
    private readonly PaginationState _guestsTablePagination = new() { ItemsPerPage = 10 };

    protected override void OnInitialized()
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

        _guests = list.AsQueryable();
    }

    private void EditGuest(Guest guest)
    {
    }

    private void DeleteGuest(Guest guest)
    {
    }

    private void AddGuest(MouseEventArgs e)
    {
    }
}