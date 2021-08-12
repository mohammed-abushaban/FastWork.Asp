using System;
using System.Collections.Generic;
using System.Text;

namespace FastWork.Core.Dto
{
    public class UpdateUserDto
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public DateTime DOB { get; set; }
    }
}
