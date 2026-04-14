using RepairShop.core.Customers;
using RepairShop.core.Entity.Orders.RepairInvoices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairShop.core.Service.Content
{
    public interface IcustomerService
    {
        Task<Customer> CreateCustomerAsync(string fullName, string email, string phoneNumber );
    }
}
