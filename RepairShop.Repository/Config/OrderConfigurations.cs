using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepairShop.core.Entity.Orders.Ticket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairShop.Repository.Config
{
    internal class OrderConfigurations:IEntityTypeConfiguration<RepairTicket>
    {

        public void Configure(EntityTypeBuilder<RepairTicket> builder)
        {
            builder.OwnsOne(order => order.ShippingAddress, ShippingAddress => ShippingAddress.WithOwner());

            builder.Property(order => order.status)
                .HasConversion
                (
                 (OStutas) => OStutas.ToString(),
                 (OStutas) => (TicketStatus)Enum.Parse(typeof(TicketStatus), OStutas)
                );
            #region This is one to one Acul

            //builder.HasOne(order => order.DeliveryMethod)
            //    .WithOne();
            //builder.HasIndex("DeliveryMethodId").IsUnique(True); 
            #endregion

            builder.HasOne(r => r.Department)
                .WithMany()
                .HasForeignKey(r => r.DepartmentId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(r => r.Engineer)
                .WithMany(e => e.RepairTickets) 
                .HasForeignKey(r => r.EngineerId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(order => order.DeliveryMethod)
               .WithMany()
               .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(r => r.Customer)
                    .WithMany(c => c.RepairTickets)
                  .HasForeignKey(r => r.CustomerId)
                 .OnDelete(DeleteBehavior.NoAction);

            builder.Property(order => order.SubTotal)
                .HasColumnType("decimal(12,2)");



            //builder.HasMany(order => order.Invoice)
            //    .WithOne()
            //    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
