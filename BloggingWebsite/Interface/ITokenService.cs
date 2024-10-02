using BloggingWebsite.Models;

namespace BloggingWebsite.Interface
{
    public interface ITokenService
    {
        Task<string> CreateToken(Users users);
    }
}
