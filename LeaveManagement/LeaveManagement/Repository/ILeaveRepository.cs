using LeaveManagement.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LeaveManagement.Repository
{
    public interface ILeaveRepository
    {
        Task<int> AddNewLeaveApplication(LeaveApplicationModel model);
        Task<List<LeaveApplicationModel>> GetAllLeaveApplications();
        Task<List<LeaveTypeModel>> GetAllLeaveTypes();
        Task<int> AddNewLeaveType(LeaveTypeModel model);
        Task<List<LeaveApplicationModel>> GetUserLeaveApplicationsById(string id);
        Task<LeaveTypeModel> GetLeaveTypeById(int id);
        Task<int> EditLeaveType(LeaveTypeModel model);
        Task<int> DeleteLeaveType(int id);
    }
}