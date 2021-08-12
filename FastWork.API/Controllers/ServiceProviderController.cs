using FastWork.Core.Dto;
using FastWork.Service.Services.ServiceProvider;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastWork.API.Controllers
{
    public class ServiceProviderController : BaseController
    {
        private IServiceProviderService _ServiceProviderService;

        public ServiceProviderController(IServiceProviderService ServiceProviderService)
        {
            _ServiceProviderService = ServiceProviderService;
        }

        [HttpGet]
        public IActionResult GetAll(int page = 1)
        {
            var sections = _ServiceProviderService.GetAll(page);
            return Ok(GetRespons(sections, "Done"));
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateServiceProviderDto dto)
        {
            _ServiceProviderService.Create(dto);
            return Ok(GetRespons());
        }


        [HttpPut]
        public IActionResult Update([FromBody] UpdateServiceProviderDto dto)
        {
            _ServiceProviderService.Update(dto);
            return Ok(GetRespons());
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _ServiceProviderService.Delete(id);

            return Ok(GetRespons(null, "Done"));
        }
    }
}
