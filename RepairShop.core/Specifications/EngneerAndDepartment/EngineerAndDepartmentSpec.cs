using RepairShop.core.RepairEngineer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairShop.core.Specifications.EngneerAndDepartment
{
    public class EngineerAndDepartmentSpec:BaseIspecifications<Engineer>
    {
        public EngineerAndDepartmentSpec():base()

        {
            includes.Add(e => e.department);
            
        }


        public EngineerAndDepartmentSpec(int id)
            :base(e=>e.Id==id)
        
        {
            includes.Add(e => e.department);
            
        }
    }
}
