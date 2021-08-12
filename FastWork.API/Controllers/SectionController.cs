using FastWork.Core.Dto;
using FastWork.Service.Services.Section;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastWork.API.Controllers
{
    public class SectionController : BaseController
    {
        private ISectionService _sectionService;

        public SectionController(ISectionService sectionService)
        {
            _sectionService = sectionService;
        }

        [HttpGet]
        public IActionResult GetAll(int page = 1)
        {
            var sections = _sectionService.GetAll(page);
            return Ok(GetRespons(sections, "Done"));
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateSectionDto dto)
        {
            _sectionService.Create(dto);
            return Ok(GetRespons());
        }


        [HttpPut]
        public IActionResult Update([FromBody] UpdateSectionDto dto)
        {
            _sectionService.Update(dto);
            return Ok(GetRespons());
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _sectionService.Delete(id);

            return Ok(GetRespons(null, "Done"));
        }
    }
}
