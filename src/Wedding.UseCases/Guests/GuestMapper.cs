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
        var guestModel = new GuestResponseModel
        {
            Id = entity.Id,
            Name = entity.Name,
            Email = entity.Email,
            Phone = entity.Phone,
            RsvpDate = entity.RsvpDate,
            IsAttending = entity.IsAttending,
            DinnerSelection = entity.DinnerSelection switch
            {
                FoodChoice.Chicken => GuestResponseModel.Dinner.Chicken,
                FoodChoice.Meatloaf => GuestResponseModel.Dinner.Meatloaf,
                _ => GuestResponseModel.Dinner.None
            },
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