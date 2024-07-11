using System.ComponentModel.DataAnnotations;

namespace Wedding.UseCases.Guests;

public class GuestModel
{
    public string? Id { get; set; }

    public string? AddressLine1 { get; set; }

    public string? City { get; set; }

    public string? Dinner { get; set; }

    [EmailAddress]
    public string? Email { get; set; }

    [Required]
    public required string Name { get; set; }

    [Phone]
    public string? Phone { get; set; }

    public string? State { get; set; }

    [StringLength(5, MinimumLength = 5)]
    public string? Zip { get; set; }

    public Guid? InvitedBy { get; set; }

    public bool? IsAttending { get; set; }

    public DateTime? RsvpDate { get; set; }
}