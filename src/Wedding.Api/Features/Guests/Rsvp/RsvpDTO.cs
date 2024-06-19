using System.ComponentModel.DataAnnotations;
using Wedding.Core.Entities.GuestAggregate;

namespace Wedding.Api.Features.Guests.Rsvp;

[Serializable]
public class RsvpDTO
{
    [Required]
    public FoodChoice DinnerSelection { get; set; }
}
