using FastWork.Core.Dto;
using FastWork.Core.Vm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastWork.Service.Services.Subsection
{
    public interface ISubsectionService
    {
        PagingVm GetAll(int page);
        void Create(CreateSubsectionDto dto);
        void Update(UpdateSubsectionDto dto);
        void Delete(int Id);
    }
}
