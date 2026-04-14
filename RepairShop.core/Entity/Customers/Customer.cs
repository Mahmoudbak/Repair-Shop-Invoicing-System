using RepairShop.core.Entity.Orders.Ticket;

namespace RepairShop.core.Customers;

public class Customer:BaseEntity
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string? Address { get; set; }

    
    public ICollection<RepairTicket> RepairTickets { get; set; } = new HashSet<RepairTicket>();//navgational prop to {Many}

}