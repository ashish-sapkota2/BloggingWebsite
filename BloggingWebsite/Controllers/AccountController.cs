using BloggingWebsite.Data;
using BloggingWebsite.DTO;
using BloggingWebsite.Interface;
using BloggingWebsite.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;

namespace BloggingWebsite.Controllers
{
    public class AccountController:BaseApiController
    {
        private readonly DapperDbContext dapper;
        private readonly ITokenService tokenService;

        public AccountController(DapperDbContext dapper,ITokenService tokenService)
        {
            this.dapper = dapper;
            this.tokenService = tokenService;
        }
        [HttpPost]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            if (await UserExists(registerDto.UserName)) return BadRequest($"{registerDto.UserName} already exists");
            var sql = "insert into Users (UserName, Email,PasswordHash,PasswordSalt,CreatedAt,FollowersCount) values(@username,@email,@PasswordHash,@PasswordSalt,@CreatedAt,@FollowersCount)";
            var username= registerDto.UserName.ToLower();
            using var hmac = new HMACSHA512();
            var PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password));
            var PasswordSalt = hmac.Key;

             using(var connection= dapper.CreateConnection())
            {
            var parameter = new
            {
                username = username,
                PasswordHash = PasswordHash,
                PasswordSalt = PasswordSalt,
                email = registerDto.Email,
                CreatedAt = DateTime.UtcNow,
                FollowersCount= 0
               

            };
                var result =  connection.QueryFirstOrDefault<Users>(sql, parameter);
                return new UserDto { 
                    Username=registerDto.UserName,
                    Token=  await tokenService.CreateToken(result)
                 
                };

            }
        }

        [HttpPost("Login")]
        public async Task<ActionResult<UserDto>>Login(LoginDto loginDto)
        {
            var sql = "select * from users where UserName=@username";
            using(var connnection= dapper.CreateConnection())
            {
                var user = await connnection.QuerySingleOrDefaultAsync<Users>(sql, new { username = loginDto.Username });
                if (user == null) return BadRequest($"{loginDto.Username} Not Found");
                //byte[] passwordSaltBytes = Convert.FromBase64String(user.PasswordSalt);
                using var hmac = new HMACSHA512(user.PasswordSalt);
                var computeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));
                for (int i = 0; i < computeHash.Length; i++)
                {
                    if (computeHash[i] != user.PasswordHash[i])
                    {
                        return Unauthorized("Invalid Password");
                    }
                }
                return new UserDto
                {
                    Username = loginDto.Username,
                    Token = await tokenService.CreateToken(user)
                };
            }

        }

        private async Task<bool>UserExists(string username)
        {
            var sql = "select username from Users where UserName=@username";
            using (var connection = dapper.CreateConnection())
            {
                var result = await connection.QueryFirstOrDefaultAsync(sql, new { username = username });
                if (result == null)
                {

                return false;
                }
                else
                {
                    return true;
                }
            }
        }
    }
}
