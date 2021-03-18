using JwtExampleConfiguration.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace JwtExampleConfiguration.AccountBusinessManagers.Interfaces
{
    public interface IAccountBusinessManager
    {
        Task<LoginResponseModel> LoginUser(LoginRequestModel loginRequestModel);
        Task<IdentityUser> GetUserById(string id);
        Task<RegisterResponseModel> RegisterUser(RegisterRequestModel registerRequestModel);
    }
}
