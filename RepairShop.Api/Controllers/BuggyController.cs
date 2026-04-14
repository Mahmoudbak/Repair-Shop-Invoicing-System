using Microsoft.AspNetCore.Mvc;
using RepairShop.Repository;

namespace Repair_Shop_Invoicing_System.Controllers;

public class BuggyController :BaseApiController
{
    private readonly StoreContext _dbcontext;

    public BuggyController(StoreContext dbcontext)
    {
        _dbcontext = dbcontext;
    }

    [HttpGet("NotFound")]
    public ActionResult GetNotFoundRequest()
    {
        return NotFound();
    }
    
    
}
