using System.ComponentModel.DataAnnotations;

namespace ProfileCardApp.Models
{
public class ContactFormViewModel
{
    [Required(ErrorMessage = "Name is required")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email address")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "Message is required")]
    [StringLength(500, ErrorMessage = "Message can't exceed 500 characters")]
    public string? Message { get; set; }
}
}
