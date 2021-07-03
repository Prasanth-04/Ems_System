using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ems_System.Data;
using Ems_System.DTO;
using Ems_System.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ems_System.Controllers
{
    public class LeaveController:BaseApiController
    {
        private readonly DataContext _context;


        public LeaveController(DataContext Context)
        {
            _context = Context;

        }
        [HttpGet("leave/{id}")]
        public async Task<ActionResult<AppLeave>> GetUser(int id )
        {
            return await _context.users_leave.FindAsync(id);


        }
       
        [HttpPost("applyleave")]
        public async Task<ActionResult<AppLeave>> Register(EmployeeDTO employeeDto)
        {
            
            var leave = new AppLeave
            {
                leavereason = employeeDto.leavereason,
                appliedate = employeeDto.appliedate,
                status = 0,
                userid = employeeDto.userid

            };
            _context.users_leave.Add(leave);
            await _context.SaveChangesAsync();
            return leave;

        }
        [HttpPut("manageleave")]
        public void Put(int id, [FromBody] LeaveStatusDTO leavestatusDto)
        {


            var entity = _context.users_leave.FirstOrDefault(u => u.userid == id);

            entity.status = leavestatusDto.status;
            



            _context.SaveChanges();


        }
    }
}
