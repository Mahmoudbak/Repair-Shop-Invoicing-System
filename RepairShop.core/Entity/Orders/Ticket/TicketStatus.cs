using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairShop.core.Entity.Orders.Ticket
{

    public enum TicketStatus
    {
        Pending,
        InProgress,
        WaitingForPayment,
        ReadyForPickup,
        Delivered
    }
}
