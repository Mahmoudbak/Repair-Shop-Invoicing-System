using RepairShop.core;
using RepairShop.core.Customers;
using RepairShop.core.Entity.Orders.RepairInvoices;
using RepairShop.core.Entity.Orders.Ticket;
using RepairShop.core.Repository.contrent;
using RepairShop.core.Service.Content;
using RepairShop.core.Specifications.orderSpec;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairShop.Services.TicketService
{
    public class TicketService : ITicketService
    {
        private readonly IUnitOfWork _unitOfWork; 


         
        public TicketService(IUnitOfWork unitOfWork)
        {
          

            _unitOfWork = unitOfWork;


        }
        public async Task<RepairTicket?> CreateTicketAsync(string customerEmail, string deviceName, string issueDescription, int departmentId, int EngineerId, int deliveryMethodId, Address shippingAddress)
        {
            // 1.get CustomerEmail
            var customerspec = new CustomerByEmailSpecification(customerEmail);

            var customer = await _unitOfWork.Repository<Customer>().GetByIdWithSpecAsync(customerspec);


            if (customer is null) return null;

            //2.deliverymethod
            var deliveryMethod =await _unitOfWork.Repository<DeliveryMethod>().GetByIdAsync(deliveryMethodId);
                if (deliveryMethod is null) return null;
            

            //3.calculate Subtotal
            var subtotal = deliveryMethod.Cost;




            //4.create ticket
           
            var Ticket = new RepairTicket
                (
                customerEmail:customerEmail,
                customerId:customer.Id,
                deviceName:deviceName,
                issueDescription:issueDescription,
                departmentId:departmentId,
                engineerId:EngineerId,
                deliverMethod : deliveryMethod, 
                subTotal:subtotal,
                shippingAddress :shippingAddress


                );

            await _unitOfWork.Repository<RepairTicket>().AddAsync(Ticket);
            //5.Save to database[TODO]
            var result = await _unitOfWork.CompleteAsync();

            if (result <= 0) return null;
            return Ticket;

        }

       public async  Task<IReadOnlyList<RepairTicket>> GetRepairTicketForUserAsync(string customerEmail)
        {

            var ticketRepo= _unitOfWork.Repository<RepairTicket>();

            var customerspec = new TicketSpecification(customerEmail);

            var ticket= await ticketRepo.GetAllWithSpecAsync(customerspec);

            return ticket;

            //var customer = await _unitOfWork.Repository<Customer>().GetByIdWithSpecAsync(customerspec);
        }


        public  Task<RepairTicket> GetRepairTicketForUserByIdAsync(int customerId, string customerEmail) 
        {
            var ticketRepo = _unitOfWork.Repository<RepairTicket>();

            var customerspec = new TicketSpecification(customerId,customerEmail);

            var ticket =  ticketRepo.GetByIdWithSpecAsync(customerspec);

            return ticket;
        }

       
        public async Task<IReadOnlyList<DeliveryMethod>> GetDeliveryMethodsAsync()
            => await _unitOfWork.Repository<DeliveryMethod>().GetAllAsync();
    }
}
