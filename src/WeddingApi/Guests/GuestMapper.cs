using Wedding.Core.Interfaces;
using WeddingApi.Core.Entities;
using WeddingApi.Guests.DTOs;

namespace WeddingApi.Guests;

[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0017:Simplify object initialization", Justification = "We want to see the line conversion fails on.")]
public class GuestMapper : IEntityModelMapper<Guest, GuestDTO>
{
    public Guest MapEntityFrom(GuestDTO model)
    {
        ArgumentNullException.ThrowIfNull(model, nameof(model));
        ArgumentNullException.ThrowIfNull(model.Name, nameof(model.Name));
        ArgumentNullException.ThrowIfNull(model.Email, nameof(model.Email));

        var guest = new Guest()
        {
            Name = model.Name,
            Email = model.Email,
        };

        return guest;
    }

    public GuestDTO MapModelFrom(Guest entity)
    {
        var guestDto = new GuestDTO();

        guestDto.Name = entity.Name;
        guestDto.Email = entity.Email;

        return guestDto;
    }
}
