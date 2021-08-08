using LeaveManagement.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LeaveManagement.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> ChangePasswordAsync(ChangePasswordModel model);
        Task<IdentityResult> ConfirmEmailAsync(string uid, string token);
        Task<IdentityResult> CreateUserAsync(SignupUserModel userModel);
        Task GenerateEmailConfirmationTokenAsync(ApplicationUser user);
        Task GenerateForgotPasswordTokenAsync(ApplicationUser user);
        Task<List<ApplicationUser>> GetAllApplicationUsers();
        List<RolesModel> GetAllRoles();
        Task<ApplicationUser> GetUserByEmailAsync(string email);
        Task<ApplicationUser> GetUserById(string id);
        Task<List<RolesModel>> GetUserRolesByIdAsync(string userId);
        Task LogoutAsync();
        Task<IdentityResult> ManageUserRolesAsync(List<RolesModel> model, string userId);
        Task<SignInResult> PasswordLoginAsync(LoginUserModel loginUserModel);
        Task<IdentityResult> ResetPasswordAsync(ResetPasswordModel model);
        Task<UpdateUserModel> GetUserModelAsync(string id);
        Task<IdentityResult> EditUserAsync(UpdateUserModel model);
        Task<IdentityResult> DeleteUserAsync(string id);
    }
}