using RepairShop.core.Entity.Orders.Ticket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairShop.core.Specifications.orderSpec
{
    public class TicketWithPaymentIntentSpecification : BaseIspecifications<RepairTicket>
    {
        public TicketWithPaymentIntentSpecification(string? paymentIntentId)
                  : base(O => O.PaymentIntentId == paymentIntentId)
        {

        }
    }
}
