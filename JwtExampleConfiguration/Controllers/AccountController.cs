using JwtExampleConfiguration.AccountBusinessManagers.Interfaces;
using JwtExampleConfiguration.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace JwtExampleConfiguration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountBusinessManager accountBusinessManager;

        public AccountController(IAccountBusinessManager accountBusinessManager)
        {
            this.accountBusinessManager = accountBusinessManager;
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> GetUserById(string id)
        {
            var identityUser = await accountBusinessManager.GetUserById(id);

            if(identityUser is null)
            {
                return NotFound();
            }

            return new UserModel(identityUser);
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponseModel>> Login(LoginRequestModel loginRequestModel)
        {
            LoginResponseModel loginResponse = await accountBusinessManager.LoginUser(loginRequestModel);
            if (string.IsNullOrEmpty(loginResponse.Token))
            {
                return new UnauthorizedObjectResult("The credentials provided are not valid.");
            }

            return loginResponse;
        }


        [HttpPost("register")]
        public async Task<ActionResult> Register(RegisterRequestModel registerRequestModel)
        {
            RegisterResponseModel registerResponseModel = await accountBusinessManager.RegisterUser(registerRequestModel);

            if (registerResponseModel.IdentityResult.Errors.Any())
            {
                registerResponseModel.IdentityResult.Errors.ToList().ForEach(error => ModelState.AddModelError(error.Code, error.Description));
                return new BadRequestObjectResult(ModelState);
            }

            var userModel = new UserModel(registerResponseModel.IdentityUser);
            return CreatedAtAction(nameof(GetUserById), new { Id = userModel.Id });
        }


    }
}
