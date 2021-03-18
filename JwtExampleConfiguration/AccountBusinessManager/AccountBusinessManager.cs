using JwtExampleConfiguration.AccountBusinessManagers.Interfaces;
using JwtExampleConfiguration.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JwtExampleConfiguration.AccountBusinessManagers
{
    public class AccountBusinessManager : IAccountBusinessManager
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly IConfiguration configuration;

        public AccountBusinessManager(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.configuration = configuration;
        }

        public async Task <IdentityUser> GetUserById(string id)
        {
            return await userManager.FindByIdAsync(id);
        }

        public async Task<LoginResponseModel> LoginUser(LoginRequestModel loginRequestModel)
        {
            var user = await userManager.FindByNameAsync(loginRequestModel.Email);
            if(user != null && await userManager.CheckPasswordAsync(user, loginRequestModel.Password))
            {
                await signInManager.SignInAsync(user, true);

                var userRoles = await userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>()
                {
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]));

                var token = new JwtSecurityToken(
                        issuer: configuration["JWT:ValidIssuer"],
                        audience: configuration["JWT:ValidAudience"],
                        expires: DateTime.Now.AddMinutes(2),
                        claims: authClaims,
                        signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );

                return new LoginResponseModel()
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    Expiration = token.ValidTo,
                    User = new UserModel(user)
                };
            }

            return new LoginResponseModel();
        }

        public async Task<RegisterResponseModel> RegisterUser(RegisterRequestModel registerRequestModel)
        {
            var identityUser = new IdentityUser()
            {
                Email = registerRequestModel.Email,
                UserName = registerRequestModel.Email
            };

            var identityResult = await userManager.CreateAsync(identityUser, registerRequestModel.Password);

            return new RegisterResponseModel()
            {
                IdentityResult = identityResult,
                IdentityUser = identityUser
            };
        }
    }
}
