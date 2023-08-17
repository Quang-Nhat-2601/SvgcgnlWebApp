using System.Security.Cryptography;
using System.Text;
using API.Data;
using API.DTO;
using API.DTOs;
using API.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class AccountController : BaseController
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public AccountController(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
            
        }
        private async Task<bool> AccountExist(string username)
        {
            return await _context.Users.AnyAsync(x => x.UserName == username);
        }

        [HttpPost("register")] // ur: api/account/register
        public async Task<ActionResult<AppUser>> Register(RegisterDTO regis_acc)
        {
            if (await AccountExist(regis_acc.UserName)) return BadRequest("User is existed");

            using var hmac = new HMACSHA512();
            var user = new AppUser {
                UserName = regis_acc.UserName,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(regis_acc.Password)),
                PasswordSalt = hmac.Key,
                Gender = regis_acc.Gender,
                KnownAs = regis_acc.KnownAs
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }

        [HttpPost("login")]
        public async Task<ActionResult<MemberDTO>> Login(LoginDTO login_acc)
        {
            var user = await _context.Users
                            .Include(a => a.Avatar)
                            .SingleOrDefaultAsync(x => x.UserName == login_acc.UserName);
            if (user == null) return Unauthorized("Invalid Username");
            using var hmac = new HMACSHA512(user.PasswordSalt);
            var computeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(login_acc.Password));
            if (computeHash == user.PasswordHash)
            for (int i = 0; i < computeHash.Length; i++)
            {
                if(computeHash[i] != user.PasswordHash[i])
                {
                    return Unauthorized("Invalid Password");
                }
            }

            var userToReturn = _mapper.Map<MemberDTO>(user);
            return userToReturn;
        }
    }
}