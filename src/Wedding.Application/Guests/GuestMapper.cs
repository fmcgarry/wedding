using Wedding.Core.Entities;
using Wedding.Core.Interfaces;

namespace Wedding.UseCases.Guests;

public class GuestMapper : IEntityModelMapper<Guest, GuestModel>
{
    public Guest MapEntityFrom(GuestModel model)
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

    public GuestModel MapModelFrom(Guest entity)
    {
        var guestDto = new GuestModel()
        {
            Name = entity.Name,
            Email = entity.Email
        };

        return guestDto;
    }
}
