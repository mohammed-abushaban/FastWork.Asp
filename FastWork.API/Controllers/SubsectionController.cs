using FastWork.Core.Dto;
using FastWork.Service.Services.Subsection;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastWork.API.Controllers
{
    public class SubsectionController : BaseController
    {
        private ISubsectionService _subsectionService;

        public SubsectionController(ISubsectionService subsectionService)
        {
            _subsectionService = subsectionService;
        }

        [HttpGet]
        public IActionResult GetAll(int page = 1)
        {
            var subsection = _subsectionService.GetAll(page);
            return Ok(GetRespons(subsection, "Done"));
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateSubsectionDto dto)
        {
            _subsectionService.Create(dto);
            return Ok(GetRespons());
        }

        [HttpPut]
        public IActionResult Update([FromBody] UpdateSubsectionDto dto)
        {
            _subsectionService.Update(dto);
            return Ok(GetRespons());
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _subsectionService.Delete(id);

            return Ok(GetRespons(null, "Done"));
        }
    }
}
