using LeaveManagement.Models;
using System.Threading.Tasks;

namespace LeaveManagement.Services
{
    public interface IEmailService
    {
        Task SendEmailConfirmationMail(UserEmailOptions userEmailOptions);
        Task SendForgotPasswordMail(UserEmailOptions userEmailOptions);
        Task SendTestEmail(UserEmailOptions userEmailOptions);
    }
}