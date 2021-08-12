using System;
using System.Collections.Generic;
using System.Text;

namespace FastWork.Core.Dto
{
    public class CreateUserDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime? DOB { get; set; }
    }
}
