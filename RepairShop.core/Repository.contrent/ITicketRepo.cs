using RepairShop.core.Entity.Orders.Ticket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairShop.core.Repository.contrent
{
    public interface ITicketRepo
    {
        Task<RepairTicket> CreateTicketAsync(string CustomerId);

        Task<RepairTicket> updateTicketAsync(string CutomerId);

        Task<bool> deleteTicketAsync(string CutomerId);


    }
}
