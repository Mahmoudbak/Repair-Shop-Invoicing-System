using Microsoft.AspNetCore.Identity;
using RepairShop.core.Identity;

namespace RepairShop.core.Service.Content;

public interface IAuthService
{   
    Task<string> CreateTokenAsync(ApplicationUser User, UserManager<ApplicationUser> userManager);
}