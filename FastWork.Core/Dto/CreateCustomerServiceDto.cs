using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastWork.Core.Dto
{
    public class CreateCustomerServiceDto
    {
        public DateTime OrberDate { get; set; }

        public float Price { get; set; }

        public int CustomerId { get; set; }

        public int ServiceId { get; set; }

    }
}
