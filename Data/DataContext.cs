using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ems_System.Entity;
using Microsoft.EntityFrameworkCore;

namespace Ems_System.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<AppUser> Employee_master { get; set; }
       
    }
}
