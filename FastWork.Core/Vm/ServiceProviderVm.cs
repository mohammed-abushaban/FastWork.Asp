using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastWork.Core.Vm
{
    public class ServiceProviderVm
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public DateTime CreatedAt { get; set; }

        public List<ServiceVm> Services { get; set; }

    }
}
