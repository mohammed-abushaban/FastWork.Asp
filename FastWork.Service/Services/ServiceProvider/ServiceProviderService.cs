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

namespace FastWork.Service.Services.ServiceProvider
{
    public class ServiceProviderService : IServiceProviderService
    {
        private ApplicationDbContext _DB;

        public ServiceProviderService(ApplicationDbContext DB)
        {
            _DB = DB;
        }

        public PagingVm GetAll(int page)
        {

            var pages = Math.Ceiling(_DB.ServiceProviders.Count() / 10.0);


            if (page < 1 || page > pages)
            {
                page = 1;
            }

            var skip = (page - 1) * 10;
            var serviceProviderVm = _DB.ServiceProviders.Include(x => x.Services).Select(x => new ServiceProviderVm() { 
                Id = x.Id,
                Email = x.Email,
                Name = x.Name,
                Phone = x.Phone,
                Services = x.Services.Select(v => new ServiceVm()
                {
                    Id = v.Id,
                    ServiceTitle = v.ServiceTitle,
                    Description = v.Description
                }).ToList()
            }).Skip(skip).Take(10).ToList();

            var pagingResult = new PagingVm();
            pagingResult.Data = serviceProviderVm;
            pagingResult.NumberOfPages = (int)pages;
            pagingResult.CureentPage = page;

            return pagingResult;
        }


        public void Create(CreateServiceProviderDto dto)
        {
            var serviceProvider = new ServiceProviderDbEntity();
            serviceProvider.Name = dto.Name;
            serviceProvider.Phone = dto.Phone;
            serviceProvider.Email = dto.Email;
            _DB.ServiceProviders.Add(serviceProvider);
            _DB.SaveChanges();
        }

        public void Update(UpdateServiceProviderDto dto)
        {
            var serviceProvider = _DB.ServiceProviders.SingleOrDefault(x => x.Id == dto.Id);
            serviceProvider.Name = dto.Name;
            serviceProvider.Phone = dto.Phone;
            serviceProvider.Email = dto.Email;
            _DB.ServiceProviders.Update(serviceProvider);
            _DB.SaveChanges();
        }

        public void Delete(int Id)
        {
            var serviceProvider = _DB.ServiceProviders.SingleOrDefault(x => x.Id == Id);
            serviceProvider.IsDelete = true;
            _DB.ServiceProviders.Update(serviceProvider);
            _DB.SaveChanges();
        }
    }
}
