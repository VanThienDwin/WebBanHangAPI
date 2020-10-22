﻿using SaleWebsiteAPI.Helper.User;
using SaleWebsiteAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleWebsiteAPI.Interfaces
{
    public interface IUserService
    {
        Task<string> Authenticate(LoginRequest request);
        //Task<bool> Register(RegisterRequest request);
        //Task<UserViewModel> getUserById(Guid userId);
        //Task<Guid> Update(UserUpdateRequest request);
        //Task<bool> ForgotPassword(ForgotPasswordRequest request);
        //Task<bool> ResetPassword(ResetPasswordRequest request);
        //Task<string> LoginWithFacebook(FacebookLoginRequest request);
    }
}
