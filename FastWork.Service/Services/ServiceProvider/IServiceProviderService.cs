using FastWork.Core.Dto;
using FastWork.Core.Vm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastWork.Service.Services.ServiceProvider
{
    public interface IServiceProviderService
    {
        PagingVm GetAll(int page);
        void Create(CreateServiceProviderDto dto);
        void Update(UpdateServiceProviderDto dto);
        void Delete(int Id);
    }
}
