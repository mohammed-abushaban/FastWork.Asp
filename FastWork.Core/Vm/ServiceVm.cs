using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastWork.Core.Vm
{
    public class ServiceVm
    {
        public int Id { get; set; }

        public string ServiceTitle { get; set; }

        public string Description { get; set; }

        public List<CustomerVm> Customers { get; set; }

        public float Price { get; set; }

    }
}
