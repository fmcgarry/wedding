using Microsoft.AspNetCore.Components.Web;

namespace Wedding.App.Components.Pages.ManageGuests;

public partial class ManageGuestsPage
{
    private IQueryable<Guest>? _guests;

    protected override void OnInitialized()
    {
        var list = new List<Guest>()
        {
            new() {Name = "Taco McGinnen"}
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