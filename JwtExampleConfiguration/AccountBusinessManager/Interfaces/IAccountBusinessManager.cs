using JwtExampleConfiguration.Data.UserEntities;
using JwtExampleConfiguration.Models;
using System.Threading.Tasks;

namespace JwtExampleConfiguration.AccountBusinessManagers.Interfaces
{
    public interface IAccountBusinessManager
    {
        Task<LoginResponseModel> LoginUser(LoginRequestModel loginRequestModel);
        Task<ApplicationUser> GetUserById(string id);
        Task<RegisterResponseModel> RegisterUser(RegisterRequestModel registerRequestModel);
    }
}
