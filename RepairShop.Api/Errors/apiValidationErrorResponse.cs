namespace Repair_Shop_Invoicing_System.Errors;

public class apiValidationErrorResponse:ApiResponse
{
    public IEnumerable<string> Errors { get; set; }
    
    public apiValidationErrorResponse() 
        : base(400)
    {
        Errors=new List<string>();
    }
}