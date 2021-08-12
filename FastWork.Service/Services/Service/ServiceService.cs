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

namespace FastWork.Service.Services.Service
{
    public class ServiceService : IServiceService
    {

        private ApplicationDbContext _DB;
        private IFileService _fileService;

        public ServiceService(ApplicationDbContext DB, IFileService fileService)
        {
            _DB = DB;
            _fileService = fileService;
        }

        public PagingVm GetAll(int page)
        {
            var pages = Math.Ceiling(_DB.Services.Count() / 10.0);

            if (page < 1 || page > pages)
            {
                page = 1;
            }

            var skip = (page - 1) * 10;

            var serviceVm = _DB.Services.Include(x => x.CustomerServices).ThenInclude(x => x.Customer)
                .Select(x => new ServiceVm()
                {
                    Id = x.Id,
                    ServiceTitle = x.ServiceTitle,
                    Description = x.Description,
                    Customers = x.CustomerServices.Select(v => new CustomerVm()
                    {
                        Id = v.Customer.Id,
                        Name = v.Customer.Name,
                        Email = v.Customer.Email,
                        Phone = v.Customer.Phone,
                    }).ToList()
                }).Skip(skip).Take(10).ToList();

            var pagingResult = new PagingVm();
            pagingResult.Data = serviceVm;
            pagingResult.NumberOfPages = (int)pages;
            pagingResult.CureentPage = page;

            return pagingResult;
        }

        public async Task Create(CreateServiseDto dto)
        {
            var servise = new ServiceDbEntity()
            {
                ServiceTitle = dto.ServiceTitle,
                Description = dto.Description,
                SubsectionId = dto.SubsectionId,
                ServiceProviderId = dto.ServiceProviderId
                
            };
            _DB.Services.Add(servise);
            _DB.SaveChanges();

            foreach (var f in dto.Files)
            {
                var FileName = await _fileService.SaveFile(f, "Files");

                var serviceFile = new FileServiceDbEntity();
                serviceFile.ServiceId = servise.Id;
                serviceFile.FileUrl = FileName;
                _DB.Files.Add(serviceFile);
            }
            _DB.SaveChanges();

        }

        public void Update(UpdateServiceDto dto)
        {
            var service = _DB.Services.SingleOrDefault(x => x.Id == dto.Id);
            service.ServiceTitle = dto.ServiceTitle;
            service.Description = dto.Description;
            service.SubsectionId = dto.SubsectionId;
            service.ServiceProviderId = dto.ServiceProviderId;
            _DB.Services.Update(service);
            _DB.SaveChanges();
        }

        public void Delete(int Id)
        {
            var service = _DB.Services.SingleOrDefault(x => x.Id == Id);
            service.IsDelete = true;
            _DB.Services.Update(service);
            _DB.SaveChanges();
        }
    }
}
