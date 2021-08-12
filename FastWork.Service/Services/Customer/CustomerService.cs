using FastWork.Core.Dto;
using FastWork.Core.Vm;
using FastWork.Data.Data;
using FastWork.Data.Models;
using FastWork.Service.Files;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastWork.Service.Services.Customer
{
    public class CustomerService : ICustomerService
    {
        private ApplicationDbContext _DB;

        public CustomerService(ApplicationDbContext DB)
        {
            _DB = DB;
        }

        public PagingVm GetAll(int page)
        {
            var pages = Math.Ceiling(_DB.Customers.Count() / 10.0);


            if (page < 1 || page > pages)
            {
                page = 1;
            }

            var skip = (page - 1) * 10;

            var customerVm = _DB.Customers.Include(x => x.CustomerServices).ThenInclude(x => x.Service)
                .Select(x => new CustomerVm() {
                    Id = x.Id,
                    Name = x.Name,
                    CreatedAt = x.CreatedAt,
                    Phone = x.Phone,
                    Email = x.Email,
                    Services = x.CustomerServices.Select(v => new ServiceVm() {
                        Id = v.Service.Id,
                        ServiceTitle = v.Service.ServiceTitle,
                        Description = v.Service.Description,
                        Price = v.Price
                    }).ToList()
                    //CustomerServiceVms = x.CustomerServices.Select(v => new CustomerServiceVm()
                    //{
                    //    Price = v.Price,
                    //    OrberDate = DateTime.Now
                    //}).ToList()
                }).Skip(skip).Take(10).ToList();

            var pagingResult = new PagingVm();
            pagingResult.Data = customerVm;
            pagingResult.NumberOfPages = (int)pages;
            pagingResult.CureentPage = page;

            return pagingResult;
        }

        public void Create(CreateCustomerDto dto)
        {
            var customer = new CustomerDbEntity()
            {
                Email = dto.Email,
                Name = dto.Name,
                Phone = dto.Phone,
                CreatedAt = dto.CreatedAt
            };

            _DB.Customers.Add(customer);
            _DB.SaveChanges();

            //foreach(var x in dto.ServiceId)
            //{
            //    var customerService = new CustomerServiceDbEntity();
            //    customerService.ServiceId = x;
            //    customerService.CustomerId = customer.Id;
            //    _DB.CustomerServices.Add(customerService);
            //    _DB.SaveChanges();
            //}

        }

        public void Update(UpdateCustomerDto dto)
        {
            var customer = _DB.Customers.SingleOrDefault(x => x.Id == dto.Id);
            customer.Email = dto.Email;
            customer.Name = dto.Name;
            customer.Phone = dto.Phone;
            foreach(var x in dto.ServiceId)
            {
                var customerService = _DB.CustomerServices.SingleOrDefault(v => v.CustomerId == dto.Id);
                customerService.ServiceId = x;
                customerService.CustomerId = customer.Id;
                _DB.CustomerServices.Update(customerService);
                _DB.SaveChanges();
            }
            _DB.Customers.Update(customer);
            _DB.SaveChanges();
        }

        public void Delete(int Id)
        {
            var customer = _DB.Customers.SingleOrDefault(x => x.Id == Id);
            customer.IsDelete = true;
            _DB.Customers.Update(customer);
            _DB.SaveChanges();
        }
    }
}
