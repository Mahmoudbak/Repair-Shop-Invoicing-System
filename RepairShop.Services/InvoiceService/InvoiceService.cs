using RepairShop.core;
using RepairShop.core.Entity.Orders.RepairInvoices;
using RepairShop.core.Entity.Orders.Ticket;
using RepairShop.core.Service.Content;
using RepairShop.core.Specifications.orderSpec;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairShop.Services.InvoiceService
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IUnitOfWork _unitOfWork;

        public InvoiceService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Invoice?> CreateInvoiceAsync(int repairTicketId)
        {
            //1.Get Ticket
            var ticket=await _unitOfWork.Repository<RepairTicket>().GetByIdAsync(repairTicketId);
            if(ticket is null) return null;

            // 2 & 3.Get Costs(SubTotal & Delivery)



           var deliveryMethod = await _unitOfWork.Repository<DeliveryMethod>().GetByIdAsync(ticket.DeliveryMethodId);

            if (deliveryMethod == null) return null;


            //var ticketRepo = _unitOfWork.Repository<RepairTicket>();

            //var spec = new TicketWithPaymentIntentSpecification(RepairTicket?.PaymentIntentId);

            //var existingOrder = await ticketRepo.GetByIdWithSpecAsync(spec);

            //if (existingOrder is not null)
            //{
            //    ticketRepo.Delete(existingOrder);
            //    await _paymentServices.CreateOrUPdatePaymentIntent(basketId);

            //}

            //4.Create Invoice
            var invoice = new Invoice
                (
                    customerEmail: ticket.CustomerEmail,
                    repairTicketId:ticket.Id,
                   totalAmout: ticket.SubTotal + deliveryMethod.Cost,
                    // paymentIntentId:ticket.PaymentIntentId,
                    deliveryMethod:deliveryMethod,
                    shippingAddress:ticket.ShippingAddress

                );
            await _unitOfWork.Repository<Invoice >().AddAsync(invoice);

            //5.save DataBase
            var result= await _unitOfWork.CompleteAsync();

            if(result<=0) return null;

            return (invoice);


        }

        public  Task<Invoice?> GetInvoiceByIdForUserAsync(int repairTicketId, string customerEmail)
        {
            var invoiceRepo =  _unitOfWork.Repository<Invoice>();
            var spec= new InvoicesSpecifications(repairTicketId,customerEmail);
            var invoices= invoiceRepo.GetByIdWithSpecAsync(spec);

            return invoices;
        }

        public async Task<IReadOnlyList<Invoice>> GetInvoicesForUserAsync(string customerEmail)
        {
            var invoiceRepo = _unitOfWork.Repository<Invoice>();
            var spec = new InvoicesSpecifications(customerEmail);
            var invoices = await invoiceRepo.GetAllWithSpecAsync(spec);

            return invoices;
        }
    }
}
