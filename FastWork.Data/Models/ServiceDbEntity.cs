using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastWork.Data.Models
{
    public class ServiceDbEntity : BaseEntity
    {
        //[Service Title, Description, Subsection ID, Customer Services, Files]
        public string ServiceTitle { get; set; }

        public string Description { get; set; }

        public SubsectionDbEntity Subsection { get; set; }

        public int SubsectionId { get; set; }

        public List<CustomerServiceDbEntity> CustomerServices { get; set; }

        public ServiceProviderDbEntity ServiceProvider { get; set; }

        public int ServiceProviderId { get; set; }

        public List<FileServiceDbEntity> Files { get; set; }
    }
}
