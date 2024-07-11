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