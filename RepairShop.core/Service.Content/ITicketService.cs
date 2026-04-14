using RepairShop.core.Entity.Orders.RepairInvoices;
using RepairShop.core.Entity.Orders.Ticket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairShop.core.Service.Content
{
    public interface ITicketService
    {
        Task<RepairTicket?> CreateTicketAsync(string customerEmail, string deviceName, string issueDescription, int departmentId,int Engineering ,int deliverMethodId, Address shippingAddress);
        Task  <IReadOnlyList<RepairTicket>> GetRepairTicketForUserAsync(string customerEmail);
        Task<RepairTicket> GetRepairTicketForUserByIdAsync(int customerId, string customerEmail);
        Task<IReadOnlyList<DeliveryMethod>> GetDeliveryMethodsAsync();
       




    }
}
