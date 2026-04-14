using RepairShop.core.Customers;
using RepairShop.core.Entity.Orders.RepairInvoices;
using RepairShop.core.Entity.Orders.Ticket;
using RepairShop.core.Entity.RepairEngineer;
using RepairShop.core.RepairEngineer;

namespace Repair_Shop_Invoicing_System.Dtos
{ 
    public class TicketDto
    {
        public string CustomerEmail { get; set; }

        public string DeviceName { get; set; }

        public string IssueDescription { get; set; }

        public DateTimeOffset IssueDate { get; set; } = DateTimeOffset.UtcNow;

        public TicketStatus status { get; set; } = TicketStatus.Pending;

        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;

        public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;

        public int DeliveryMethodId { get; set; }
        public AddressDto ShippingAddress { get; set; } = null!;

        public int EngineerId { get; set; }


        public int CustomerId { get; set; }


        public int DepartmentId { get; set; }

    }
}
