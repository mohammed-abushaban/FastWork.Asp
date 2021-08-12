using FastWork.Core.Dto;
using FastWork.Core.Vm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastWork.Service.Services.Section
{
    public interface ISectionService
    {
        PagingVm GetAll(int page);
        void Create(CreateSectionDto dto);
        void Update(UpdateSectionDto dto);
        void Delete(int id);
    }
}
