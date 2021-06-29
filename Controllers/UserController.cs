using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ems_System.Data;
using Ems_System.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Ems_System.Controllers
{
    public class UserController:BaseApiController
    {
        private readonly DataContext _context;

        public UserController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("users")]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUser()
        {
            return await _context.Employee_master.ToListAsync();


        }
    }
}
