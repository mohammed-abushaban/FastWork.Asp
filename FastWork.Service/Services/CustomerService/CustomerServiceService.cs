using FastWork.Core.Dto;
using FastWork.Core.Vm;
using FastWork.Data.Data;
using FastWork.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastWork.Service.Services.CustomerService
{
    public class CustomerServiceService : ICustomerServiceService
    {
        private ApplicationDbContext _DB;

        public CustomerServiceService(ApplicationDbContext DB)
        {
            _DB = DB;
        }
        
        public bool Create(CreateCustomerServiceDto dto)
        {

            var customer = _DB.Customers.SingleOrDefault(x => x.Id == dto.CustomerId);
            var service = _DB.Sections.SingleOrDefault(x => x.Id == dto.ServiceId);

            if (customer == null || service == null)
            {
                return false;
            }

            var customerService = new CustomerServiceDbEntity()
            {
                CustomerId = dto.CustomerId,
                ServiceId = dto.ServiceId,
                Price = dto.Price,
                OrberDate = DateTime.Now
            };
            _DB.CustomerServices.Add(customerService);
            _DB.SaveChanges();
            return true;
        }

        public void Update(UpdateCustomerServiceDto dto)
        {
            var customerService = _DB.CustomerServices
                .SingleOrDefault(x => x.CustomerId == dto.CustomerId && x.ServiceId == dto.ServiceId);
            customerService.Price = dto.Price;
            customerService.OrberDate = DateTime.Now;
            _DB.CustomerServices.Update(customerService);
            _DB.SaveChanges();
        }

        public void Delete(int serviceId, int customerId)
        {
            var customerService = _DB.CustomerServices.SingleOrDefault(x => x.CustomerId == customerId && x.ServiceId == serviceId);
            customerService.IsDelete = true;
            _DB.CustomerServices.Update(customerService);
            _DB.SaveChanges();
        }

        
    }
}
