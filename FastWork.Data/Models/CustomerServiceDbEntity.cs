using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastWork.Data.Models
{
    public class CustomerServiceDbEntity
    {
        //[Order Date, Price, Customer ID, Service ID]
        public int CustomerId { get; set; }

        public CustomerDbEntity Customer { get; set; }

        public int ServiceId { get; set; }

        public ServiceDbEntity Service { get; set; }

        public DateTime OrberDate { get; set; }

        public float Price { get; set; }

        public bool IsDelete { get; set; }
    }
}
