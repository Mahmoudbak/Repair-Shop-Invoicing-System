using RepairShop.core.Entity.Orders.RepairInvoices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairShop.core.Service.Content
{
    public interface IInvoiceService
    {
        Task<Invoice?> CreateInvoiceAsync(int repairTicketId);
        Task<IReadOnlyList<Invoice>> GetInvoicesForUserAsync(string customerEmail);
        Task<Invoice?> GetInvoiceByIdForUserAsync(int repairTicketId, string customerEmail);
    } 
}
