using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastWork.Data.Models
{
    public class ServiceProviderDbEntity : BaseEntity
    {
        //[Name, Phone, Email, Services]

        public string Name { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public List<ServiceDbEntity> Services { get; set; }

    }
}
