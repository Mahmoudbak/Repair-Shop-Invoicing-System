namespace Repair_Shop_Invoicing_System.Errors;

public class ApiExceptionResponse:ApiResponse
{
    public string? Details { get; set; }
    public ApiExceptionResponse(int statusCode, string? message=null,string? details=null) 
        : base(statusCode, message)
    {
        Details = details;
    }
}