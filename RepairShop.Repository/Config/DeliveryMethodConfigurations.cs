using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepairShop.core.Entity.Orders.RepairInvoices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairShop.Repository.Config
{
    internal class DeliveryMethodConfigurations
    {
        public void Configure(EntityTypeBuilder<DeliveryMethod> builder)
        {
            builder.Property(DeliveryMethod => DeliveryMethod.Cost)
                .HasColumnType("decimal(12,2)");
        }
    }
}
