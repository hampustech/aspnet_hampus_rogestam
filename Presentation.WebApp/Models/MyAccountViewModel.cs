using System.ComponentModel.DataAnnotations;

namespace Presentation.WebApp.Models;

public class MyAccountViewModel
{
    public string? UserId { get; set; }

    [Display(Name = "First Name")]
    public string? FirstName { get; set; }

    [Display(Name = "Last Name")]
    public string? LastName { get; set; }

    public string? Email { get; set; }

    [Phone(ErrorMessage = "Invalid phone number")]
    [Display(Name = "Phone Number")]
    public string? PhoneNumber { get; set; }
}