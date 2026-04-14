using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Repair_Shop_Invoicing_System.Dtos;
using Repair_Shop_Invoicing_System.Errors;
using Repair_Shop_Invoicing_System.Helper;
using RepairShop.core;
using RepairShop.core.Identity;
using RepairShop.core.Repository.contrent;
using RepairShop.core.Service.Content;
using RepairShop.Repository;
using RepairShop.Repository._Identity;
using RepairShop.Repository.Genaric_Repository;
using RepairShop.Services.AuthService;
using RepairShop.Services.CustomerService;
using RepairShop.Services.InvoiceService;
using RepairShop.Services.TicketService;
using System.Text;

namespace Repair_Shop_Invoicing_System.Extensions;

public static class ApplicationServicesExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {



        #region Configer Services

       // services.AddScoped<IAuthService, AuthService>();
       services.AddScoped(typeof(IUnitOfWork),typeof(UnitOfWork));
       services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped(typeof(ITicketService),typeof(TicketService));
        services.AddScoped(typeof(IInvoiceService), typeof(InvoiceService));
        services.AddScoped<IcustomerService, CustomerService>();



        //services.AddScoped<IAuthService, AuthService>();
        //services.AddAutoMapper(typeof(MappingProfile).Assembly);
        services.AddAutoMapper(cfg => cfg.AddProfile<MappingProfile>());
        //  services.AddAutoMapper(typeof(MappingProfile));


        #endregion

        #region use all Project using for handiler the error and validaion




        services.Configure<ApiBehaviorOptions>(Options =>
        {
            Options.InvalidModelStateResponseFactory = (Actioncontext) =>
            {
                var Error = Actioncontext.ModelState.Where(p => p.Value.Errors.Count() < 0)
                    .SelectMany(p => p.Value.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToArray();
                var response = new apiValidationErrorResponse()
                {
                    Errors = Error
                };
                return new BadRequestObjectResult(response);
            };

        });

        #endregion
        return services;
    }


    public static IServiceCollection AddAuthService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddIdentity<ApplicationUser, IdentityRole>(options => { })
            .AddEntityFrameworkStores<ApplicationIdentityDbContext>();

        services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
               // options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidIssuer = configuration["Jwt:AuthIssuer"],
                    ValidateAudience = true,
                    ValidAudience = configuration["Jwt:AuthAudience"],
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey =
                        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:AuthKey"] ?? string.Empty)),
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                });
        return services;
    }
        
}