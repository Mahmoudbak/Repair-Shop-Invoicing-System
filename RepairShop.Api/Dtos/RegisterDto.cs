using System.ComponentModel.DataAnnotations;

namespace Repair_Shop_Invoicing_System.Dtos;

public class RegisterDto
{
    [Required]
    public string DisplayName { get; set; }
    
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    
    
    [Required]
    public string Phone { get; set; }
    
    [Required]
    [DataType(DataType.Password)]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^A-Za-z0-9])\S{8,64}$",
        ErrorMessage = "Password must be 8–64 chars, with upper, lower, digit, and special character.")]
    public string Password { get; set; }
    
}