using Microsoft.AspNetCore.Identity;
using ATSB.Api.Areas.Identity.Entities.Security;
using ATSB.Models;
using ATSB.Helpers;

namespace ATSB.Helpers
{
    public class UserHelper : IUserHelper
    {
        private readonly UserManager<UserAtsb> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<UserAtsb> _signInManager;

        public UserHelper(
            UserManager<UserAtsb> userManager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<UserAtsb> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> AddUserAsync(UserAtsb user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }

        public async Task AddUserToRoleAsync(UserAtsb user, string roleName)
        {
            await _userManager.AddToRoleAsync(user, roleName);
        }

        public async Task CheckRoleAsync(string roleName)
        {
            var roleExists = await _roleManager.RoleExistsAsync(roleName);
            if (!roleExists)
            {
                await _roleManager.CreateAsync(new IdentityRole
                {
                    Name = roleName
                });
            }
        }

        public async Task<UserAtsb> GetUserByEmailAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            return user;
        }

        public async Task<bool> IsUserInRoleAsync(UserAtsb user, string roleName)
        {
            return await _userManager.IsInRoleAsync(user, roleName);

        }

        public async Task<IdentityResult> ConfirmEmailAsync(UserAtsb user, string token)
        {
            return await _userManager.ConfirmEmailAsync(user, token);
        }

        public async Task<string> GenerateEmailConfirmationTokenAsync(UserAtsb user)
        {
            return await _userManager.GenerateEmailConfirmationTokenAsync(user);
        }

        public async Task<SignInResult> ValidatePasswordAsync(UserAtsb user, string password)
        {
            return await _signInManager.CheckPasswordSignInAsync(
                user,
                password,
                false);
        }
        public async Task<SignInResult> LoginAsync(LoginRequest model)
        {
            return await _signInManager.PasswordSignInAsync(
                model.Username,
                model.Password,
                model.RememberMe,
                false);
        }

        public async Task<UserAtsb> GetUserByIdAsync(string userId)
        {
            return await _userManager.FindByIdAsync(userId);
        }

        public async Task<string> GeneratePasswordResetTokenAsync(UserAtsb user)
        {
            return await _userManager.GeneratePasswordResetTokenAsync(user);
        }

        public async Task<IdentityResult> ResetPasswordAsync(UserAtsb user, string token, string password)
        {
            return await _userManager.ResetPasswordAsync(user, token, password);
        }
        public async Task<IdentityResult> ChangePasswordAsync(UserAtsb user, string oldPassword, string newPassword)
        {
            return await _userManager.ChangePasswordAsync(user, oldPassword, newPassword);
        }
    }
}