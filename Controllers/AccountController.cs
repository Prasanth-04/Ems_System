using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
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
        public async Task<ActionResult<AppUser>> Register(RegisterDTO registerDto )
        {
            ManagerDTO managerDTO = new ManagerDTO();
            if (await UserExists(registerDto.Username)) return BadRequest("Username is taken");
            using var hmac = new HMACSHA512();
            var user = new AppUser
            {
                username = registerDto.Username.ToLower(),
                passwordhash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                passwordsalt = hmac.Key,
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

            using var hmac = new HMACSHA512(user.passwordsalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.password));
            
            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.passwordhash[i]) return Unauthorized("Invalid Password");
            }

            return user;
           
            

        }
        [HttpDelete("delete")]
        public void delete(int id)
        {
            try
            {
                _context.Employee_master.Remove(_context.Employee_master.FirstOrDefault(e => e.userid == id));
            }
            catch (Exception)
            {

                BadRequest("invalid user id ");
            }
           
            
            _context.SaveChanges(); 

            
        }




        [HttpPut("update")]
        public void Put(int id,[FromBody]RegisterDTO registerDto)
        {

            using var hmac = new HMACSHA512();
            var entity = _context.Employee_master.FirstOrDefault(u => u.userid == id);

                entity.name = registerDto.name;
                entity.age = registerDto.age;
                entity.department = registerDto.department;
                entity.username = registerDto.Username;
                entity.role = registerDto.role;
            entity.passwordhash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password));
            entity.passwordsalt = hmac.Key;



                _context.SaveChanges();
            

        }

        private async Task<bool> UserExists(string username)
        {
            return await _context.Employee_master.AnyAsync(X => X.username == username.ToLower());
        }

        
    }
}
