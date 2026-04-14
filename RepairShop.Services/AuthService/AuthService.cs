using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RepairShop.core.Identity;
using RepairShop.core.Service.Content;

namespace RepairShop.Services.AuthService;

public class AuthService:IAuthService
{
    private readonly IConfiguration _configuration;

    public AuthService(IConfiguration  configuration)
    {
        _configuration = configuration;
    }

    
    
    public async Task<string> CreateTokenAsync(ApplicationUser User, UserManager<ApplicationUser> userManager)
    {
        var authcliam = new List<Claim>()
        {
            new Claim(ClaimTypes.Name , User.DisplayName),
            new Claim(ClaimTypes.Email, User.Email),
        };
        var userRole=await userManager.GetRolesAsync(User);
        foreach (var Role in userRole)
        {
            authcliam.Add(new Claim(ClaimTypes.Role, Role));
        }
        
        
        var authKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:AuthKey"]??String.Empty));

        var Token = new JwtSecurityToken    
        (
            audience: _configuration["Jwt:AuthAudience"],
            issuer: _configuration["Jwt:AuthIssuer"],
            expires: DateTime.Now.AddDays(double.Parse(_configuration["Jwt:DurationInDays"]??"0")),
            claims: authcliam,
            signingCredentials:new SigningCredentials(authKey,SecurityAlgorithms.HmacSha256Signature)
        );

        return new JwtSecurityTokenHandler().WriteToken(Token);

    }
}