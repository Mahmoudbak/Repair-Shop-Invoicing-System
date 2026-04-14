using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Repair_Shop_Invoicing_System.Dtos;
using Repair_Shop_Invoicing_System.Errors;
using Repair_Shop_Invoicing_System.SinglR;
using RepairShop.core.Customers;
using RepairShop.core.Entity.Orders.RepairInvoices;
using RepairShop.core.Entity.Orders.Ticket;
using RepairShop.core.Service.Content;
using System.Security.Claims;

namespace Repair_Shop_Invoicing_System.Controllers
{

    public class TicketController : BaseApiController
    {
        private readonly ITicketService _ticketService;
        private readonly IMapper _mapper;
        private readonly IHubContext<NotificationHub> _hubContext;

        public TicketController(ITicketService ticketService,
            IMapper mapper,
            IHubContext<NotificationHub> hubContext)
        {
            _ticketService = ticketService;
            _mapper = mapper;
            _hubContext = hubContext;
        }


        [Authorize]
        [ProducesResponseType(typeof(TicketToReturnDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<ActionResult<TicketDto>> CreateRepairTicket(TicketDto TicketDto)
        {
            var customerEmail = User.FindFirstValue(ClaimTypes.Email);

            var orderAddress = _mapper.Map<AddressDto, Address>(TicketDto.ShippingAddress);

            var ticket = await _ticketService.CreateTicketAsync(customerEmail, TicketDto.DeviceName, TicketDto.IssueDescription, TicketDto.DepartmentId, TicketDto.EngineerId, TicketDto.DeliveryMethodId, orderAddress);
            if (ticket == null) return BadRequest(new ApiResponse(400, "An error occured during the creation of the order"));


            //SignalR
            await _hubContext.Clients.All.SendAsync("ReceiveNewTicketNotification",
                $"New ticket created for device: {ticket.DeviceName} by {customerEmail}");


            return Ok(ticket);
        }


        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<TicketToReturnDto>>> GetRepairTickets()
        {
            var customerEmail = User.FindFirstValue(ClaimTypes.Email);

            var ticket = await _ticketService.GetRepairTicketForUserAsync(customerEmail);

            return Ok(_mapper.Map<IReadOnlyList<RepairTicket>, IReadOnlyList<TicketToReturnDto>>(ticket));



        }


        [Authorize]
        [ProducesResponseType(typeof(TicketToReturnDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [HttpGet("{id}")]
        public async Task<ActionResult<TicketToReturnDto>> GetRepairTicketById(int id)
        {

            var customer = User.FindFirstValue(ClaimTypes.Email);

            var ticket = await _ticketService.GetRepairTicketForUserByIdAsync(id, customer);
            if (ticket is null) return NotFound(new ApiResponse(404));


            return Ok(_mapper.Map<RepairTicket, TicketToReturnDto>(ticket));

        }

         [Authorize]
         [HttpGet("deliveryMethods")] // Get : api/Ticket/deliverymethods
          public async Task<ActionResult<IReadOnlyList<DeliveryMethod>>> GetDeliveryMethods()
          {
                var deliveryMethod = await _ticketService.GetDeliveryMethodsAsync();

                return Ok(deliveryMethod);
          }


        


    }
}
