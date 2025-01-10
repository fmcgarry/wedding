using Wedding.Core.Entities.GuestAggregate;
using Wedding.Core.Interfaces;

namespace Wedding.UseCases.Guests;

public class GuestMapper : IEntityModelMapper<Guest, GuestModel>
{
    public Guest MapEntityFrom(GuestModel model)
    {
        var guest = new Guest()
        {
            Id = model.Id is not null ? Guid.Parse(model.Id) : Guid.NewGuid(),
            Name = model.Name,
            Email = model.Email,
        };

        return guest;
    }

    public GuestModel MapModelFrom(Guest entity)
    {
        var guestModel = new GuestModel
        {
            Id = entity.Id.ToString(),
            Name = entity.Name,
            Email = entity.Email,
            Phone = entity.Phone,
            RsvpDate = entity.RsvpDate,
            IsAttending = entity.IsAttending,
            Dinner = entity.DinnerSelection.ToString()
        };

        if (entity.Address is not null)
        {
            guestModel.AddressLine1 = entity.Address.Line1;
            guestModel.City = entity.Address.City;
            guestModel.State = entity.Address.State.ToString();
            guestModel.Zip = entity.Address.Zip;
        }

        return guestModel;
    }
}