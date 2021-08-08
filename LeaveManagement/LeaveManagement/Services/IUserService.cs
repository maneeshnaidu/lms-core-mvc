namespace LeaveManagement.Services
{
    public interface IUserService
    {
        string GetUserId();
        bool IsAuthenticated();
    }
}