using RepairShop.core.Entity.Orders.Ticket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairShop.core.Specifications.orderSpec
{
    public class TicketSpecification:BaseIspecifications<RepairTicket>
    {
        public TicketSpecification(string customerEmail)
        :base(c=>c.CustomerEmail==customerEmail)
        {
            includes.Add(o => o.DeliveryMethod);
            includes.Add(o => o.Engineer);
            includes.Add(o => o.Customer);
            includes.Add(o => o.Department);
            AddOrderByDesc(o=>o.IssueDate);
        }
        public TicketSpecification(int customerId, string customerEmail)
         :base(c=>c.Id==customerId && c.CustomerEmail == customerEmail)
        {
            includes.Add(o => o.DeliveryMethod);
            includes.Add(o => o.Engineer);
            includes.Add(o => o.Customer);
            includes.Add(o => o.Department);
            AddOrderByDesc(o => o.IssueDate);

        }
    }
}
