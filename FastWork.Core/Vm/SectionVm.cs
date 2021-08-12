using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastWork.Core.Vm
{
    public class SectionVm
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public List<SubsectionVm> Subsections { get; set; }

        public List<CustomerServiceVm> MyProperty { get; set; }

    }
}
