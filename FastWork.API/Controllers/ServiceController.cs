using FastWork.Core.Dto;
using FastWork.Service.Services.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastWork.API.Controllers
{
    public class ServiceController : BaseController
    {
        private IServiceService _ServiceService;

        public ServiceController(IServiceService ServiceService)
        {
            _ServiceService = ServiceService;
        }

        [HttpGet]
        public IActionResult GetAll(int page = 1)
        {
            var sections = _ServiceService.GetAll(page);
            return Ok(GetRespons(sections, "Done"));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateServiseDto dto)
        {
            await _ServiceService.Create(dto);
            return Ok(GetRespons());
        }


        [HttpPut]
        public IActionResult Update([FromBody] UpdateServiceDto dto)
        {
            _ServiceService.Update(dto);
            return Ok(GetRespons());
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _ServiceService.Delete(id);

            return Ok(GetRespons(null, "Done"));
        }
    }
}
