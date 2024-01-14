using System.ComponentModel.DataAnnotations;

namespace Wedding.App.Components.Pages.Rsvp;

public class RsvpModel
{
    public string Name { get; set; } = string.Empty;

    [Phone]
    public string Phone { get; set; } = string.Empty;

    public DinnerSelection DinnerSelection { get; set; } = DinnerSelection.None;
    public List<RsvpModel> Guests { get; set; } = [];
}