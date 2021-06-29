using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ems_System.Entity
{
    public class AppUser
    {   
        [Key]
        public int userid { get; set; }
        public string name { get; set; }
        public DateTime joiningdate { get; set; }
        public int age { get; set; }
        public string department { get; set; }

        public string username { get; set; }

        public string password { get; set; }

        public int role { get; set; }/*0-admin,1-manager,2-employee*/
    }
}
