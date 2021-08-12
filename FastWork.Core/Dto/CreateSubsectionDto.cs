using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastWork.Core.Dto
{
    public class CreateSubsectionDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int SectionId { get; set; }
    }
}
