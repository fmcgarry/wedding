using System.ComponentModel.DataAnnotations;

namespace Wedding.UseCases.Guests;

public record GuestResponseModel([property: Required] Guid Id, [property: Required] string Name, [property: EmailAddress] string? Email);
