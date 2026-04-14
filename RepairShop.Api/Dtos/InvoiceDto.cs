using System.ComponentModel.DataAnnotations;

namespace Repair_Shop_Invoicing_System.Dtos
{
    public class InvoiceDto
    {

        [Required]
        public string TicketId { get; set; }
        [Required]
        public int DeliveryMethodId { get; set; }//DeliveryMethodId

        public AddressDto ShippingAddress { get; set; } = null!;
    } 
}
