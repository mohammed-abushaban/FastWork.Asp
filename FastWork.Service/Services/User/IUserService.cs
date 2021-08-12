using FastWork.Core.Dto;
using FastWork.Core.Vm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastWork.Service.Services.User
{
    public interface IUserService
    {
        List<UserVm> GetUsers();
        Task<bool> Create(CreateUserDto dto);
        Task Update(UpdateUserDto dto);
        void Delete(string Id);
    }
}
