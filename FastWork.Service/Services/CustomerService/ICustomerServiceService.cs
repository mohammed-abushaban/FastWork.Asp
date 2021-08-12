using FastWork.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastWork.Service.Services.CustomerService
{
    public interface ICustomerServiceService
    {
        bool Create(CreateCustomerServiceDto dto);
        void Update(UpdateCustomerServiceDto dto);
        void Delete(int serviceId, int customerId);
    }
}
