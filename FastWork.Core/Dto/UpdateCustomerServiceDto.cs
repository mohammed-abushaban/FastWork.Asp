using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastWork.Core.Dto
{
    public class UpdateCustomerServiceDto
    {
        public int ServiceId { get; set; }

        public int CustomerId { get; set; }

        public float Price { get; set; }

        public DateTime OrberDate { get; set; }
    }
}
