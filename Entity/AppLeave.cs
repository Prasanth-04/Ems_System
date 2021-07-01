using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ems_System.Entity
{
    public class AppLeave
    {
        [Key]
        public int leaveid { get; set; }
        public string leavereason { get; set; }
        public DateTime appliedate { get; set; }

        public int status { get; set; }
        public int userid { get; set; }

    }
}
