using Bogus;
using WeddingApp.Clients.WeddingApi.Models;
using WeddingApp.Components.Pages.Rsvp;

namespace WeddingApp.Clients.WeddingApi;

public class FakeWeddingApiClient : IWeddingApiClient
{
    private readonly List<Guest> _guests = [];

    public FakeWeddingApiClient()
    {
        Seed();
    }

    public Task<ClientResult> AddGuestAsync(Guest guest)
    {
        _guests.Add(guest);
        return Task.FromResult(ClientResult.Success());
    }

    public Task<ClientResult<IEnumerable<Guest>>> GetAllGuestsAsync()
    {
        return Task.FromResult(ClientResult.Success(_guests.AsEnumerable()));
    }

    private void Seed()
    {
        var dummyGuests = new Faker<Guest>("en_US")
            .RuleFor(g => g.Address, (f, u) => f.Address.FullAddress())
            .RuleFor(g => g.Dinner, (f, u) => f.PickRandom<DinnerSelection>().ToString())
            .RuleFor(g => g.InvitedBy, (f, u) => f.Name.FullName())
            .RuleFor(g => g.Name, (f, u) => f.Name.FullName())
            .RuleFor(g => g.Phone, (f, u) => f.Phone.PhoneNumber("###-###-####"))
            .RuleFor(g => g.Rsvp, (f, u) => f.PickRandom<Guest.RsvpState>());

        _guests.AddRange(dummyGuests.Generate(10));
    }
}