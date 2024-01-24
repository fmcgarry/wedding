using Wedding.Core.Entities.GuestAggregate;
using Wedding.Core.Interfaces;

namespace Wedding.UseCases.Guests;

public class GuestMapper : IEntityModelMapper<Guest, GuestResponseModel>
{
    public Guest MapEntityFrom(GuestResponseModel model)
    {
        var guest = new Guest()
        {
            Id = model.Id,
            Name = model.Name,
            Email = model.Email,
        };

        return guest;
    }

    public GuestResponseModel MapModelFrom(Guest entity)
    {
        var guestModel = new GuestResponseModel(entity.Id, entity.Name, entity.Email);

        return guestModel;
    }
}