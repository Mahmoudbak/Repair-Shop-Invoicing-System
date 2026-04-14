using RepairShop.core.Customers;
using RepairShop.core.Entity.Orders.Ticket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairShop.core.Specifications.orderSpec
{
    public class CustomerByEmailSpecification:BaseIspecifications<Customer>
    {
        public CustomerByEmailSpecification(String CustomerEmail)
        :base(c=>c.Email==CustomerEmail)
        {
            
        }
    }
}
