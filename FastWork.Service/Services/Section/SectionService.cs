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


namespace FastWork.Service.Services.Section
{
    public class SectionService : ISectionService
    {
        private ApplicationDbContext _DB;


        public SectionService(ApplicationDbContext DB)
        {
            _DB = DB;
        }


        public PagingVm GetAll(int page)
        {

            var pages = Math.Ceiling(_DB.Sections.Count() / 10.0);


            if (page < 1 || page > pages)
            {
                page = 1;
            }

            var skip = (page - 1) * 10;
            var sectionVm = _DB.Sections.Include(x => x.Subsections).Select(x => new SectionVm()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                CreatedAt = x.CreatedAt,
                Subsections = x.Subsections.Select(v => new SubsectionVm()
                {
                    Id = v.Id,
                    Description = v.Description,
                    Name = v.Name
                }).ToList()
            }).Skip(skip).Take(10).ToList();


            var pagingResult = new PagingVm();
            pagingResult.Data = sectionVm;
            pagingResult.NumberOfPages = (int)pages;
            pagingResult.CureentPage = page;

            return pagingResult;

        }

        public void Create(CreateSectionDto dto)
        {
            var section = new SectionDbEntity();
            section.Name = dto.Name;
            section.Description = dto.Description;
            _DB.Sections.Add(section);
            _DB.SaveChanges();
        }

        public void Update(UpdateSectionDto dto)
        {
            var section = _DB.Sections.SingleOrDefault(x => x.Id == dto.Id);
            section.Name = dto.Name;
            section.Description = dto.Description;
            _DB.Sections.Update(section);
            _DB.SaveChanges();
        }


        public void Delete(int id)
        {
            var section = _DB.Sections.SingleOrDefault(x => x.Id == id);
            section.IsDelete = true;
            _DB.Sections.Update(section);
            _DB.SaveChanges();
        }

    }
}
