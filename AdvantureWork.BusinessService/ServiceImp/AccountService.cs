using AdvantureWork.BusinessService.Interface;
using AdvantureWork.Common.Helper;
using AdvantureWork.Common.Request;
using AdvantureWork.Model.Entities;
using AdvantureWork.ViewModels.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AdvantureWork.BusinessService.ServiceImp
{
    public class AccountService : BaseClass, IAccountService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IConfiguration _config;
       
        public AccountService(UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            RoleManager<AppRole> roleManager,
            IConfiguration config)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _config = config;
        }

        public async Task<ApiResult<string>> Authencate(LoginRequest request)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(request.Email);
                if (user == null) return new ApiErrorResult<string>("Account does'n exist!");

                var result = await _signInManager.PasswordSignInAsync(user, request.Password, request.RememberMe, true);
                if (!result.Succeeded)
                {
                    return new ApiErrorResult<string>("Login invalid");
                }
                var roles = await _userManager.GetRolesAsync(user);
                var claims = new[]
                {
                new Claim(ClaimTypes.Email,user.Email),
                //new Claim(ClaimTypes.GivenName,user.FirstName),
                new Claim(ClaimTypes.Role, string.Join(";",roles)),
                new Claim(ClaimTypes.Name, request.Email)
            };
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(_config["Tokens:Issuer"],
                    _config["Tokens:Issuer"],
                    claims,
                    expires: DateTime.Now.AddHours(3),
                    signingCredentials: creds);

                // Test
                var json = File.ReadAllText(Directory.GetCurrentDirectory() + "/appsettings.json");

                return new ApiSuccessResult<string>(new JwtSecurityTokenHandler().WriteToken(token));
            }
            catch (Exception ex)
            {
                var result = new ApiErrorResult<string>(ex.Message);
                Console.WriteLine(ex.Message);
                return result;
            }
        }

        public async Task<ApiResult<bool>> Register(RegisterRequest request)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(request.Email);
                if (user != null)
                {
                    return new ApiErrorResult<bool>("Account already exist!");
                }
                if (await _userManager.FindByEmailAsync(request.Email) != null)
                {
                    return new ApiErrorResult<bool>("Emai already exist!");
                }

                user = new AppUser()
                {
                    Email = request.Email,
                    FullName = request.FullName,
                    UserName = request.Email,
                    PhoneNumber = request.PhoneNumber
                };
                var result = await _userManager.CreateAsync(user, request.Password);
                if (result.Succeeded)
                {
                    return new ApiSuccessResult<bool>();
                }
                return new ApiErrorResult<bool>("Can't registry!");
            }
            catch (Exception ex)
            {
                var result = new ApiErrorResult<bool>(ex.Message);
                Console.WriteLine(ex.Message);
                return result;
            }
        }

        public new void Dispose()
        {
            if (_roleManager != null)
            {
                _roleManager.Dispose();
            }

            if (_userManager != null)
            {
                _userManager.Dispose();
            }

            base.Dispose();
        }
    }
}