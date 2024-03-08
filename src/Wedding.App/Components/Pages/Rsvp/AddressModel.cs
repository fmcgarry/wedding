using System.ComponentModel.DataAnnotations;

namespace WeddingApp.Components.Pages.Rsvp;

public class AddressModel
{
    [Required(ErrorMessage = "Please enter your name.")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Please enter your address.")]
    public string Address { get; set; } = string.Empty;

    [Required(ErrorMessage = "Please enter a city.")]
    public string City { get; set; } = string.Empty;

    [Required(ErrorMessage = "Please select a state.")]
    public string State { get; set; } = string.Empty;

    [Required(ErrorMessage = "Please enter a zip code.")]
    [StringLength(6)]
    public string Zip { get; set; } = string.Empty;

    [Required(ErrorMessage = "Please enter a phone number.")]
    [Phone(ErrorMessage = "Please enter a valid phone number. (e.g., 123-456-7890)")]
    public string Phone { get; set; } = string.Empty;
}
