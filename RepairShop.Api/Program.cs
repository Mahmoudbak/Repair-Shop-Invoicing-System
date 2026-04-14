using Microsoft.EntityFrameworkCore;
using Repair_Shop_Invoicing_System.Extensions;
using Repair_Shop_Invoicing_System.MiddleWares;
using Repair_Shop_Invoicing_System.SinglR;
using RepairShop.core.Service.Content;
using RepairShop.Repository;
using RepairShop.Repository._Identity;
using RepairShop.Services.AuthService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

builder.Services.AddControllers().AddNewtonsoftJson(Options => 
{
    Options.SerializerSettings.ReferenceLoopHandling=Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});
builder.Services.AddOpenApi();

builder.Services.AddApplicationServices();

builder.Services.AddDbContext<StoreContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
}
    );
builder.Services.AddDbContext<ApplicationIdentityDbContext>(option =>
{
         option.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection"));   
}
    );


builder.Services.AddApplicationServices();
builder.Services.AddScoped(typeof(IAuthService), typeof(AuthService));
builder.Services.AddAuthService(builder.Configuration);
builder.Services.AddSignalR();
builder.Services.AddControllers(); 





var app = builder.Build();

#region Apply All pending Migration [update _database ]And Data Seeding

using var scope = app.Services.CreateScope();//Dispose the scope after build-->using
var services = scope.ServiceProvider;//ask CLR For create object From DBcontext explicitly

var _dbContext = services.GetRequiredService<StoreContext>();
var _Identitydbcontext = services.GetRequiredService<ApplicationIdentityDbContext>();

var loggerFactory = services.GetRequiredService<ILoggerFactory>();
try
{
    await _dbContext.Database.MigrateAsync();
    
    await _Identitydbcontext.Database.MigrateAsync();
    
    
}
catch (Exception ex)
{
    Console.WriteLine(ex);
    var logger = loggerFactory.CreateLogger<Program>();
    logger.LogError(ex, "An error occurred Migration");
}


#endregion
app.UseStatusCodePagesWithRedirects("/Error/{0}");
app.UseMiddleware<ExptionMiddleWare>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options => options.SwaggerEndpoint(url: "/openapi/v1.json", name: "Repair Shop Invoicing System API"));
}

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.MapHub<NotificationHub>("/notificationHub");
app.MapControllers();
app.Run();

