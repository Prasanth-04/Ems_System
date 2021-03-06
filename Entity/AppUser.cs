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
        public string joiningdate { get; set; }
        public int age { get; set; }
        public string department { get; set; }

        public string username { get; set; }

        public byte[] passwordhash { get; set; }

        public byte[] passwordsalt { get; set; }


        public int role { get; set; }/*0-admin,1-manager,2-employee*/

       
    }
}
