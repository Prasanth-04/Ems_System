using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ems_System.DTO
{
    public class EmployeeDTO
    {
        
        [Required]
        public string leavereason { get; set; }
        [Required]
        public string appliedate { get; set; }
        public int status { get; set; }/* 0=approved, 1=pending, 2=declined*/
        [Key]
        public int userid { get; set; }
    }
}
