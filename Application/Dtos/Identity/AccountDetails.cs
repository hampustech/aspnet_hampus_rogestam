namespace Application.Dtos.Identity;

public record AccountDetails
(
    string? UserId = null,
    string? Email = null,
    string? FirstName = null,
    string? LastName = null,
    string? PhoneNumber = null
);

public record UpdateAccountDetails
(
    string? UserId = null,
    string? Email = null,
    string? FirstName = null,
    string? LastName = null,
    string? PhoneNumber = null
);