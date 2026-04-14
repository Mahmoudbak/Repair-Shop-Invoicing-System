using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Repair_Shop_Invoicing_System.Dtos;
using Repair_Shop_Invoicing_System.Errors;
using RepairShop.core.Entity.Orders.RepairInvoices;
using RepairShop.core.Entity.Orders.Ticket;
using RepairShop.core.Service.Content;
using System.Net.Sockets;
using System.Security.Claims;

namespace Repair_Shop_Invoicing_System.Controllers
{
    [Authorize]
    public class InvoiceController :BaseApiController
    {
        private readonly IInvoiceService _invoiceService;
        private readonly IMapper _mapper;

        public InvoiceController(IInvoiceService invoiceService,IMapper mapper)
        {
            _invoiceService = invoiceService;
            _mapper = mapper;
        }


        [HttpPost("{ticketId}")]
        public async Task<ActionResult<InvoiceDto>> CreateInvoiceForTicket(int TicketId)
        { 
            var invoice= await _invoiceService.CreateInvoiceAsync(TicketId);

            if (invoice is null)
                return null;

            return Ok(_mapper.Map<Invoice,InvoiceDto>(invoice));
        
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<InvoiceDto>>> GetInvoices()
        {
            var email=User.FindFirstValue(ClaimTypes.Email);
            var invoice=await _invoiceService.GetInvoicesForUserAsync(email);

            if (invoice is null) return null;

            return Ok(_mapper.Map<IReadOnlyList<Invoice>,IReadOnlyList< InvoiceDto>>(invoice));

        }



        [HttpGet("{ticketId}")]
        public async Task<ActionResult<InvoiceDto>> GetInvoiceByTicketId(int ticketId)

        {

            var email = User.FindFirstValue(ClaimTypes.Email)!;

            var invoice = await _invoiceService.GetInvoiceByIdForUserAsync(ticketId, email);

            if (invoice == null)
                return NotFound(new ApiResponse(404, "No invoice found for this ticket"));

            return Ok(_mapper.Map<Invoice, InvoiceDto>(invoice));
        }



    }
}
