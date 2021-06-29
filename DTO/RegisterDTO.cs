using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ems_System.DTO
{
    public class RegisterDTO
    {
       
        [Required]
        public string name { get; set; }
        [Required]
        public DateTime joiningdate { get; set; }
        [Required]
        public int age { get; set; }
        [Required]
        public string department { get; set; }
        [Required]

        public string Username { get; set; }
        [Required]

        public string Password { get; set; }
        [Required]

        public int role { get; set; }
    }
}
