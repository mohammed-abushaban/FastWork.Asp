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

namespace FastWork.Service.Services.Subsection
{
    public class SubsectionService : ISubsectionService
    {
        private ApplicationDbContext _DB;

        public SubsectionService(ApplicationDbContext DB)
        {
            _DB = DB;
        }

        public PagingVm GetAll(int page)
        {

            var pages = Math.Ceiling(_DB.Subsections.Count() / 10.0);


            if (page < 1 || page > pages)
            {
                page = 1;
            }

            var skip = (page - 1) * 10;

            var subsectionVm = _DB.Subsections.Include(x => x.Section).Include(x => x.Services)
                .Select(x => new SubsectionVm() { 
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Services = x.Services.Select(v => new ServiceVm()
                    {
                        Id = v.Id,
                        Description = v.Description,
                        ServiceTitle = v.ServiceTitle
                    }).ToList()
                }).Skip(skip).Take(10).ToList();

            var pagingResult = new PagingVm();
            pagingResult.Data = subsectionVm;
            pagingResult.NumberOfPages = (int)pages;
            pagingResult.CureentPage = page;

            return pagingResult;
        }

        public void Create(CreateSubsectionDto dto)
        {
            var subsection = new SubsectionDbEntity();
            subsection.Description = dto.Description;
            subsection.Name = dto.Name;
            subsection.SectionId = dto.SectionId;
            _DB.Subsections.Add(subsection);
            _DB.SaveChanges();
        }

        public void Update(UpdateSubsectionDto dto)
        {
            var subsection = _DB.Subsections.SingleOrDefault(x => x.Id == dto.Id);
            subsection.Description = dto.Description;
            subsection.Name = dto.Name;
            _DB.Subsections.Update(subsection);
            _DB.SaveChanges();
        }

        public void Delete(int Id)
        {
            var subsection = _DB.Subsections.SingleOrDefault(x => x.Id == Id);
            subsection.IsDelete = true;
            _DB.Subsections.Update(subsection);
            _DB.SaveChanges();
        }
    }
}
