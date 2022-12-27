using Microsoft.AspNetCore.Identity;
using ATSB.Api.Areas.Identity.Entities.Security;
using ATSB.Models;

namespace ATSB.Helpers
{
    public interface IUserHelper
    {
        Task<UserAtsb> GetUserByEmailAsync(string email);

        Task<IdentityResult> AddUserAsync(UserAtsb user, string password);

        Task CheckRoleAsync(string roleName);

        Task AddUserToRoleAsync(UserAtsb user, string roleName);

        Task<bool> IsUserInRoleAsync(UserAtsb user, string roleName);

        Task<string> GenerateEmailConfirmationTokenAsync(UserAtsb user);

        Task<IdentityResult> ConfirmEmailAsync(UserAtsb user, string token);

        Task<SignInResult> ValidatePasswordAsync(UserAtsb user, string password);

        Task<SignInResult> LoginAsync(LoginRequest model);

        Task<UserAtsb> GetUserByIdAsync(string userId);
        Task<string> GeneratePasswordResetTokenAsync(UserAtsb user);

        Task<IdentityResult> ResetPasswordAsync(UserAtsb user, string token, string password);

        Task<IdentityResult> ChangePasswordAsync(UserAtsb user, string oldPassword, string newPassword);
    }
}