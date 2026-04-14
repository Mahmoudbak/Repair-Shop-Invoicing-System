using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepairShop.core.Entity.Orders.RepairInvoices;

namespace RepairShop.Repository.Config.Invoice_config;

public class InvoiceConfiguration:IEntityTypeConfiguration<Invoice>
{
    public void Configure(EntityTypeBuilder<Invoice> builder)
    {
        builder.Property(i=>i.TotalAmount)
            .HasColumnType("decimal(18,2)");

       
    }
}