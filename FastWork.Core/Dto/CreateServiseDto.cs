using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastWork.Core.Dto
{
    public class CreateServiseDto
    {
        public string ServiceTitle { get; set; }

        public string Description { get; set; }

        public int SubsectionId { get; set; }

        public int ServiceProviderId { get; set; }

        public List<IFormFile> Files { get; set; }

    }
}
