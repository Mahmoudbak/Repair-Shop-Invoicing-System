using RepairShop.core.Customers;
using RepairShop.core.Entity.Orders.RepairInvoices;
using RepairShop.core.Entity.RepairEngineer;
using RepairShop.core.Identity;
using RepairShop.core.RepairEngineer;
using System.ComponentModel.DataAnnotations.Schema;

namespace RepairShop.core.Entity.Orders.Ticket;


public class RepairTicket:BaseEntity
{
    private RepairTicket()
    {
        
    }
    public RepairTicket(string customerEmail,int customerId, string deviceName, string issueDescription, int departmentId, int engineerId, DeliveryMethod? deliverMethod,decimal subTotal, Address shippingAddress)
    {
        if (deliverMethod == null)
        {
            throw new Exception("🛑 كارثة: الـ DeliveryMethod وصل هنا بـ NULL!");
        }
        CustomerEmail = customerEmail; 
        CustomerId= customerId;
        DeviceName=deviceName;
        IssueDescription=issueDescription;
        DepartmentId=departmentId;
        EngineerId=engineerId;
        DeliveryMethod = deliverMethod;
        SubTotal = subTotal;
        ShippingAddress=shippingAddress;

    }
    public string  CustomerEmail { get; set; }
    public string DeviceName { get; set; }

   public string IssueDescription { get; set; }
   
   public DateTimeOffset IssueDate { get; set; } = DateTimeOffset.UtcNow;

    public TicketStatus status { get; set; }=TicketStatus.Pending;

    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;



    public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;

    public int DeliveryMethodId { get; set; }
    public DeliveryMethod? DeliveryMethod { get; set; } = null!;
    public decimal SubTotal { get; set; }
    public decimal GetTotal()
     => SubTotal + DeliveryMethod.Cost;
    public Address ShippingAddress { get; set; } = null!;

    public string? PaymentIntentId { get; set; }

    [ForeignKey("Engineer")] 
    public int EngineerId { get; set; }
    public Engineer Engineer { get; set; }

    [ForeignKey("Customer")] 
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }

    public int DepartmentId { get; set; }
    public Department Department { get; set; }

   public Invoice Invoice { get; set; }




}