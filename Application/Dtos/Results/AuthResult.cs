namespace Application.Dtos.Results;

public sealed record AuthResult(bool Succeeded, string? ErrorMessage = "error")
{
    public static AuthResult Ok() => new(true);
    public static AuthResult Failed(string errorMessage) => new(false, errorMessage);
};