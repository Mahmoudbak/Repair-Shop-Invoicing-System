using RepairShop.core.Entity.Orders.RepairInvoices;

using RepairShop.core.Entity.Orders.Ticket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairShop.core.Specifications.orderSpec
{
    public class InvoicesSpecifications : BaseIspecifications<Invoice>
    {
        public InvoicesSpecifications(string CustomerEmail) 
            :base(e=>e.CustomerEmail==CustomerEmail)
        {
            includes.Add(o => o.DeliveryMethod);
            includes.Add(o => o.RepairTicket);
            //AddOrderByDesc(o=>o.);
        }

        public InvoicesSpecifications(int orderId, string buyerEmail) :
           base(O => O.Id == orderId && O.CustomerEmail == buyerEmail)
        {
            includes.Add(o => o.DeliveryMethod);
            includes.Add(o => o.RepairTicket);

        }



    }
}
