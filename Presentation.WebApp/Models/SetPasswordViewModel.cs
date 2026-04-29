using System.ComponentModel.DataAnnotations;

namespace Presentation.WebApp.Models;

public class SetPasswordViewModel
{
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "Password is required")]
    [MinLength(10, ErrorMessage = "Password must be at least 10 characters")]
    public string Password { get; set; } = null!;

    public bool AcceptTerms { get; set; }
}