using RepairShop.core.Entity.Orders.RepairInvoices;

namespace Repair_Shop_Invoicing_System.Dtos
{
    public class TicketToReturnDto
    {

        public int Id { get; set; }

        public string CustomerEmail { get; set; }


        public string DeviceName { get; set; }


        public string IssueDescription { get; set; }

        public DateTimeOffset IssueDate { get; set; }

        public string Status { get; set; }

        public Address ShippingAddress { get; set; }


        public string DeliveryMethod { get; set; }


        public decimal DeliveryMethodCost { get; set; }

        public decimal SubTotal { get; set; }


        public decimal Total { get; set; }


        public string PaymentInentId { get; set; } = string.Empty;
    }
}
