using FastWork.Core.Dto;
using FastWork.Service.Services.CustomerService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastWork.API.Controllers
{
    public class CustomerServiceController : BaseController
    {
        private ICustomerServiceService _customerServiseService;

        public CustomerServiceController(ICustomerServiceService customerServiseService)
        {
            _customerServiseService = customerServiseService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateCustomerServiceDto dto)
        {
            var result = _customerServiseService.Create(dto);
            return Ok(GetRespons(result));
        }


        [HttpPut]
        public IActionResult Update([FromBody] UpdateCustomerServiceDto dto)
        {
            _customerServiseService.Update(dto);
            return Ok(GetRespons());
        }

        [HttpDelete]
        public IActionResult Delete(int serviceId, int customerId)
        {
            _customerServiseService.Delete(serviceId, customerId);

            return Ok(GetRespons(null, "Done"));
        }
    }
}
