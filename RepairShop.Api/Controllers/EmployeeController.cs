using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepairShop.core.RepairEngineer;
using RepairShop.core.Repository.contrent;
using RepairShop.core.Specifications.EngneerAndDepartment;
using RepairShop.Repository.Genaric_Repository;

namespace Repair_Shop_Invoicing_System.Controllers
{
  
    public class EmployeeController :BaseApiController
    {
        private readonly IGenericRepository<Engineer> _employeesrepo;

        public EmployeeController(IGenericRepository<Engineer> employeesrepo)
        {
            _employeesrepo = employeesrepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Engineer>>> GetAllEngineer()
        {
            var spec = new EngineerAndDepartmentSpec();
            var emp=await  _employeesrepo.GetAllWithSpecAsync(spec);


            return Ok(emp);

        }


        [HttpGet]
        public async Task<ActionResult<Engineer>> GetEngineerbyId(int id)
        {

            var spec=new EngineerAndDepartmentSpec(id);

            var emp=await _employeesrepo.GetByIdWithSpecAsync(spec);
            return Ok(emp);






        }









    }
}
