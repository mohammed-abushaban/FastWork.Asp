using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastWork.Data.Models
{
    public class SectionDbEntity : BaseEntity
    {
        //[Name, Description, Subsections]
        public string Name { get; set; }

        public string Description { get; set; }

        public List<SubsectionDbEntity> Subsections { get; set; }


    }
}
