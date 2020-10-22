using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SaleWebsiteAPI.Data;
using SaleWebsiteAPI.Enums;
using SaleWebsiteAPI.Helper;
using SaleWebsiteAPI.Helper.User;
using SaleWebsiteAPI.Interfaces;
using SaleWebsiteAPI.Model;
using SaleWebsiteAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SaleWebsiteAPI.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        readonly SignInManager<AppUser> _signInManager;
        private readonly ShopDbContext _context;
        private readonly IConfiguration _config;
        public UserService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ShopDbContext context, IConfiguration config)/*, , RoleManager<AppRole> roleManager,*/
        //, , IStorageService storageService, EmailConfiguration emailConfiguration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            //_roleManager = roleManager;
            _config = config;
            _context = context;
            //_storageService = storageService;
            //_emailConfiguration = emailConfiguration;
        }
        public async Task<string> Authenticate(LoginRequest request)
        {
            //kiểm trả thằng username có hay chưa
            var user = await _userManager.FindByNameAsync(request.username);
            if (user == null || user.status == ActionStatus.Deleted)
            {
                return null;
            }
            var result = await _signInManager.PasswordSignInAsync(user, request.password, true, true);
            if (!result.Succeeded)
            {
                return null;
            }
            var roles = await _userManager.GetRolesAsync(user);
            var claims = new[]
            {
                new Claim("userId", user.Id.ToString()),
                new Claim("fullname", user.displayname),
                new Claim("role", roles[0]),
                new Claim("avatar", user.avatar!=null? user.avatar:"")
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(_config["Tokens:Issuer"],
                _config["Tokens:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(180),
                signingCredentials: creds
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }    
        

    //public Task<bool> ForgotPassword(ForgotPasswordRequest request)
    //{
    //    throw new NotImplementedException();
    //}

    //public Task<UserViewModel> getUserById(Guid userId)
    //{
    //    throw new NotImplementedException();
    //}

    //public Task<string> LoginWithFacebook(FacebookLoginRequest request)
    //{
    //    throw new NotImplementedException();
    //}

    //public Task<bool> Register(RegisterRequest request)
    //{
    //    throw new NotImplementedException();
    //}

    //public Task<bool> ResetPassword(ResetPasswordRequest request)
    //{
    //    throw new NotImplementedException();
    //}

    //public Task<Guid> Update(UserUpdateRequest request)
    //{
    //    throw new NotImplementedException();
    //}
}
}
