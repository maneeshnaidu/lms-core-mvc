using LeaveManagement.Data;
using LeaveManagement.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LeaveManagement.Repository
{
    public interface ILeaveAllocationRepository
    {
        Task<bool> CheckAllocation(int leaveTypeId, string employeeId);
        Task<bool> Create(LeaveAllocation entity);
        Task<bool> Delete(LeaveAllocation entity);
        Task<ICollection<LeaveAllocation>> FindAll();
        Task<LeaveAllocation> FindById(int id);
        Task<List<LeaveAllocationModel>> GetLeaveAllocationsByEmployee(string employeeid);
        Task<LeaveAllocation> GetLeaveAllocationsByEmployeeAndType(string employeeid, int leavetypeid);
        Task<bool> isExists(int id);
        Task<bool> Save();
        Task SetLeave(string userId);
        Task<bool> Update(LeaveAllocation entity);
    }
}