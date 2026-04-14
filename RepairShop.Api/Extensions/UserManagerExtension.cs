using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RepairShop.core.Identity;

namespace Repair_Shop_Invoicing_System.Extensions;

public static class UserManagerExtension
{
    public static async Task<ApplicationUser?> FindUserWithAddressAsync(this UserManager<ApplicationUser> userManager, ClaimsPrincipal User)

 {
   var email=User.FindFirstValue(ClaimTypes.Email);
   var user=await userManager.Users.Include(U=>U.Address).SingleOrDefaultAsync(u=>u.Email==email);
   return user;
       
  
 }
}