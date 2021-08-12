using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastWork.Data.Models
{
    public class FileServiceDbEntity
    {
        public int Id { get; set; }

        public ServiceDbEntity Service { get; set; }

        public int ServiceId { get; set; }

        [Required]
        public string FileUrl { get; set; }
    }
}
    