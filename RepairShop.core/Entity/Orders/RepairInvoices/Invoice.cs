using RepairShop.core.Entity.Orders.Ticket;

namespace RepairShop.core.Entity.Orders.RepairInvoices;
    public  enum PaymentStatus { Unpaid, Paid }

public class Invoice:BaseEntity
{
    private Invoice()
    {
        
    }
    public Invoice(string customerEmail,int repairTicketId, decimal totalAmout, DeliveryMethod? deliveryMethod, Address shippingAddress)
    {
        CustomerEmail=customerEmail;
        RepairTicketId=repairTicketId;

         TotalAmount = totalAmout;
        //paymentIntentId=PaymentIntentId;
        DeliveryMethod = deliveryMethod;
        ShippingAddress = shippingAddress;
    }
    public string CustomerEmail { get; set; }

    public decimal TotalAmount { get; set; }
    
    public string? PaymentIntentId { get; set; }
    public DeliveryMethod? DeliveryMethod { get; set; }
    //public decimal SubTotal { get; set; }

    public decimal GetTotal()
           => TotalAmount + DeliveryMethod.Cost;

    public DateTime? PaidAt { get; set; }
    public int RepairTicketId { get; set; }
    public RepairTicket RepairTicket { get; set; }
    public Address ShippingAddress { get; set; } = null!;



}