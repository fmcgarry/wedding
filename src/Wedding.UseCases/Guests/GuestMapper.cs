using Wedding.Core.Entities.GuestAggregate;
using Wedding.Core.Interfaces;

namespace Wedding.UseCases.Guests;

public class GuestMapper : IEntityModelMapper<Guest, GuestModel>
{
    public Guest MapEntityFrom(GuestModel model)
    {
        var guest = new Guest()
        {
            Id = model.Id,
            Name = model.Name,
            Email = model.Email,
        };

        return guest;
    }

    public GuestModel MapModelFrom(Guest entity)
    {
        var guestModel = new GuestModel()
        {
            Id = entity.Id,
            Name = entity.Name,
            Email = entity.Email
        };

        return guestModel;
    }
}