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
    public class AccountController:BaseApiController
    {
        private readonly DataContext _context;
       

        public AccountController(DataContext Context)
        {
            _context = Context;
           
        }
        [HttpPost("register")]
        public async Task<ActionResult<AppUser>> Register(RegisterDTO registerDto)
        {
            if (await UserExists(registerDto.Username)) return BadRequest("Username is taken");
            var user = new AppUser
            {
                username = registerDto.Username.ToLower(),
                password = registerDto.Password,
                joiningdate = registerDto.joiningdate,
                name = registerDto.name,
                age = registerDto.age,
                department = registerDto.department,
                role = registerDto.role

            };
            _context.Employee_master.Add(user);
            await _context.SaveChangesAsync();
            return user;
           
        }
        [HttpPost("login")]
        public  async  Task<ActionResult<AppUser>> Login(LoginDTO loginDto)
        {
            var user = await _context.Employee_master.SingleOrDefaultAsync(x => x.username == loginDto.username);
            if (user == null) return Unauthorized("Invalid Username");
            for (int i = 0; i < loginDto.password.Length; i++)
            {
                if (loginDto.password[i] != user.password[i]) return Unauthorized("Invalid Password");
            }

            return user;
           
            

        }
        private async Task<bool> UserExists(string username)
        {
            return await _context.Employee_master.AnyAsync(X => X.username == username.ToLower());
        }
    }
}
