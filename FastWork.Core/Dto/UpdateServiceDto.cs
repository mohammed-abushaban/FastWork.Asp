using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastWork.Core.Dto
{
    public class UpdateServiceDto
    {
        public int Id { get; set; }

        public string ServiceTitle { get; set; }

        public string Description { get; set; }

        public int SubsectionId { get; set; }

        public int ServiceProviderId { get; set; }
    }
}
