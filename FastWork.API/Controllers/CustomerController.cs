using FastWork.Core.Dto;
using FastWork.Service.Services.Customer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastWork.API.Controllers
{
    public class CustomerController : BaseController
    {
        private ICustomerService _customerServise;

        public CustomerController(ICustomerService customerServise)
        {
            _customerServise = customerServise;
        }

        [HttpGet]
        public IActionResult GetAll(int page = 1)
        {
            var sections = _customerServise.GetAll(page);
            return Ok(GetRespons(sections, "Done"));
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateCustomerDto dto)
        {
            _customerServise.Create(dto);
            return Ok(GetRespons());
        }


        [HttpPut]
        public IActionResult Update([FromBody] UpdateCustomerDto dto)
        {
            _customerServise.Update(dto);
            return Ok(GetRespons());
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _customerServise.Delete(id);

            return Ok(GetRespons(null, "Done"));
        }
    }
}
