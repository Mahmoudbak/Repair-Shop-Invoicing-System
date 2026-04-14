using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using Repair_Shop_Invoicing_System.Errors;

namespace Repair_Shop_Invoicing_System.MiddleWares;

public class ExptionMiddleWare
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExptionMiddleWare> _logger;
    private readonly IWebHostEnvironment _env;

    public ExptionMiddleWare(RequestDelegate next,ILogger<ExptionMiddleWare> logger , IWebHostEnvironment env)
    {
        _next = next;
        _logger = logger;
        _env = env;
    }


    public async Task Invoke(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            httpContext.Response.ContentType = "application/json";



            var response = _env.IsDevelopment() ?
                 new ApiExceptionResponse((int)HttpStatusCode.InternalServerError, e.Message, e.StackTrace)
                : 
                new ApiExceptionResponse((int)HttpStatusCode.InternalServerError, e.Message, e.StackTrace);

            var option= new JsonSerializerOptions(){PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            
            var json = JsonSerializer.Serialize(response, option);
            await httpContext.Response.WriteAsync(json);

        }
    }
}