using RepairShop.core;
using RepairShop.core.Customers;
using RepairShop.core.Entity.Orders.RepairInvoices;
using RepairShop.core.Service.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairShop.Services.CustomerService
{
    public class CustomerService : IcustomerService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Customer> CreateCustomerAsync(string fullName, string email, string phoneNumber )
        {
      
            var customer = new Customer
            {
                FullName = fullName,
                Email = email,
                PhoneNumber = phoneNumber,

            };
            _unitOfWork.Repository<Customer>().AddAsync(customer);
            await _unitOfWork.CompleteAsync(); // ده اللي هيكتب في الداتابيز

            return customer;
        }
    }
}
