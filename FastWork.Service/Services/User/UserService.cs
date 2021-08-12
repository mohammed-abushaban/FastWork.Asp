using FastWork.Core.Dto;
using FastWork.Core.Vm;
using FastWork.Data.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastWork.Service.Services.User
{
    public class UserService : IUserService
    {
        private ApplicationDbContext _DB;
        private UserManager<FastWork.Data.Models.User> _userManager;

        public UserService(ApplicationDbContext DB, UserManager<FastWork.Data.Models.User> userManager)
        {
            _DB = DB;
            _userManager = userManager;
        }

        public List<UserVm> GetUsers()
        {
            var users = _DB.Users.Where(x => !x.IsDelete).Select(x => new UserVm()
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email,
                PhoneNumber = x.PhoneNumber,
                DOB = x.DOB
            }).ToList();

            return users;
        }

        public async Task<bool> Create(CreateUserDto dto)
        {
            var user = new FastWork.Data.Models.User();
            user.FirstName = dto.FirstName;
            user.LastName = dto.LastName;
            user.Email = dto.Email;
            user.PhoneNumber = dto.PhoneNumber;
            user.DOB = dto.DOB;
            user.CreatedAt = DateTime.Now;
            user.UserName = dto.PhoneNumber;

            var result = await _userManager.CreateAsync(user, "123456789#m");

            return result.Succeeded;

        }

        public async Task Update(UpdateUserDto dto)
        {
            var user = _DB.Users.SingleOrDefault(x => x.Id == dto.Id && !x.IsDelete);
            user.FirstName = dto.FirstName;
            user.LastName = dto.LastName;
            user.Email = dto.Email;
            user.DOB = dto.DOB;
            user.CreatedAt = DateTime.Now;

            await _userManager.UpdateAsync(user);

        }

        public void Delete(string Id)
        {
            var user = _DB.Users.SingleOrDefault(x => x.Id == Id && !x.IsDelete);
            user.IsDelete = true;
            _DB.Users.Update(user);
            _DB.SaveChanges();
        }

    }
}
