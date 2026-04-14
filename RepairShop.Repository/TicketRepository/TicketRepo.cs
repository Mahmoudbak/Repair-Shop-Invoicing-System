using Microsoft.EntityFrameworkCore.Storage;
using RepairShop.core.Entity.Orders.Ticket;
using RepairShop.core.Repository.contrent;
using RepairShop.core.Service.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairShop.Repository.TicketRepository
{
    public class TicketRepo : ITicketRepo
    {
        private readonly StoreContext _dbContext;


        public Task<RepairTicket> CreateTicketAsync(string CustomerId)
        {
            throw new NotImplementedException();
        }

        public Task<RepairTicket> updateTicketAsync(string CutomerId)
        {
            throw new NotImplementedException();
        }
        public Task<bool> deleteTicketAsync(string CutomerId)
        {
            throw new NotImplementedException();
        }
    }
}
