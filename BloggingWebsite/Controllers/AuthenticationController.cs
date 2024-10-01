using BloggingWebsite.Data;
using BloggingWebsite.DTO;
using Dapper;
using Microsoft.AspNetCore.Mvc;

namespace BloggingWebsite.Controllers
{
    public class AuthenticationController:BaseApiController
    {
        private readonly DapperDbContext dapper;

        public AuthenticationController(DapperDbContext dapper)
        {
            this.dapper = dapper;
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            if (await UserExists(registerDto.UserName)) return BadRequest($"{registerDto.UserName} already exists");


            
         
        }

        private async Task<bool>UserExists(string username)
        {
            var sql = "select username from Users where UserName=@username";
            using (var connection = dapper.CreateConnection())
            {
                var result = await connection.QueryFirstOrDefaultAsync(sql, new { username = username });
                return result;
            }
        }
    }
}
