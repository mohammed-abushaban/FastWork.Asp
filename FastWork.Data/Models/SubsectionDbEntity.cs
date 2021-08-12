using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastWork.Data.Models
{
    public class SubsectionDbEntity : BaseEntity
    {
        //[Name, Description, Section ID, Services]

        public string Name { get; set; }

        public string Description { get; set; }

        public SectionDbEntity Section { get; set; }

        public int SectionId { get; set; }

        public List<ServiceDbEntity> Services { get; set; }

    }
}
