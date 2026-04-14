using Microsoft.AspNetCore.Identity;
using RepairShop.core.Entity.Identity;

namespace RepairShop.core.Identity;

public class ApplicationUser:IdentityUser
{
    public string DisplayName { get; set; } = null!;
    public Address? Address { get; set; } = null!;



    // public string  { get; set; }
}