using FastWork.Core.Dto;
using FastWork.Core.Vm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastWork.Service.Services.Service
{
    public interface IServiceService
    {
        PagingVm GetAll(int page);
        Task Create(CreateServiseDto dto);
        void Update(UpdateServiceDto dto);
        void Delete(int Id);
    }
}
