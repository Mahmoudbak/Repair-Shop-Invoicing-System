using System.Security.AccessControl;
using RepairShop.core.Entity.Orders.Ticket;
using RepairShop.core.Entity.RepairEngineer;

namespace RepairShop.core.RepairEngineer;

public class Engineer:BaseEntity
{
    public string FullName { get; set; }
    
    public string Email { get; set; }
    
    public string PhoneNumber { get; set; }


    public Department department { get; set; }

    public ICollection<RepairTicket> RepairTickets { get; set; } = new HashSet<RepairTicket>();//navgational prop to {Many}

    
}