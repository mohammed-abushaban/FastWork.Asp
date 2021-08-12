using FastWork.Core.Dto;
using FastWork.Core.Vm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastWork.Service.Services.Customer
{
    public interface ICustomerService
    {
        PagingVm GetAll(int page);
        void Create(CreateCustomerDto dto);
        void Update(UpdateCustomerDto dto);
        void Delete(int Id);
    }
}
