using AutoMapper;
using Repair_Shop_Invoicing_System.Dtos;
using RepairShop.core.Entity.Orders.RepairInvoices;
using RepairShop.core.Entity.Orders.Ticket;


//using RepairShop.core.Entity.Identity;
using RepairShop.core.Identity;
using RepairShop.core.Service.Content;
using RepairShop.Services.InvoiceService;
using static System.Net.WebRequestMethods;

namespace Repair_Shop_Invoicing_System.Helper;

public class MappingProfile:Profile
{
    public MappingProfile()
    {
        CreateMap<AddressDto, RepairShop.core.Entity.Identity.Address>().ReverseMap();


        CreateMap<AddressDto, Address>().ReverseMap(); ;


        CreateMap<RepairTicket, TicketDto>().ReverseMap(); ;
        CreateMap<RepairTicket,TicketToReturnDto>()
            .ForMember(d=>d.DeliveryMethod,o=>o.MapFrom(s=>s.DeliveryMethod.ShortName))
            .ForMember(d => d.DeliveryMethodCost, o => o.MapFrom(s => s.DeliveryMethod.Cost))
            .ForMember(d=>d.Status,o=>o.MapFrom(s=>s.status.ToString()))
            .ForMember(d=>d.Total,o=>o.MapFrom(s=>s.SubTotal+s.DeliveryMethod.Cost));




        CreateMap<Invoice, InvoiceDto>()
            .ForMember(d => d.TicketId, o => o.MapFrom(s => s.RepairTicketId.ToString()));
        
    }
}