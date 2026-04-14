using System.Reflection;
using Microsoft.EntityFrameworkCore;
using RepairShop.core.Customers;
using RepairShop.core.Entity.Orders.RepairInvoices;
using RepairShop.core.Entity.Orders.Ticket;
using RepairShop.core.Entity.RepairEngineer;
using RepairShop.core.RepairEngineer;

namespace RepairShop.Repository;


public class StoreContext:DbContext
{
    public StoreContext(DbContextOptions<StoreContext>options)
        :base(options)
    {
     
    }
   
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
  
    }
    public DbSet<Customer> Customers { get; set; }

    public DbSet<RepairTicket> RepairTickets { get; set; }

    public DbSet<Invoice> Invoices { get; set; }

    public DbSet<Engineer> Engineers { get; set; }
    public DbSet<Department> Departments {  get; set; }
    public DbSet<DeliveryMethod>DeliveryMethods      { get; set; }

}