using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ems_System.Entity
{
    public class AppManager
    {
        [Key]
        public int managerid { get; set; }

        public string name { get; set; }

        public int userid { get; set; }
    }
}
