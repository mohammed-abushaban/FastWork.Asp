using FastWork.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastWork.Data.Data
{
    public class SDatabase : DbContext
    {

        public SDatabase(DbContextOptions<SDatabase> options)
           : base(options)
        {
      
        }

        public DbSet<Car> Cars { get; set; }
    }
}
