using LeaveManagement.Data;
using LeaveManagement.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManagement.Repository
{
    public class LeaveRepository : ILeaveRepository
    {
        private readonly ApplicationDbContext _context = null;

        public LeaveRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<LeaveApplicationModel>> GetAllLeaveApplications()
        {
            return await _context.LeaveApplications
                .Select(application => new LeaveApplicationModel()
                {
                    Id = application.Id,
                    UserId = application.UserId,
                    LeaveTypeId = application.LeaveTypeId,
                    FromDate = application.FromDate,
                    LeaveDays = application.LeaveDays,
                    LeaveReason = application.LeaveReason,
                    Employee = application.User,
                    LeaveType = application.LeaveType.Type

                }).ToListAsync();
        }

        public async Task<int> AddNewLeaveApplication(LeaveApplicationModel model)
        {
            var newApplication = new LeaveApplication()
            {
                UserId = model.UserId,
                LeaveTypeId = model.LeaveTypeId,
                FromDate = model.FromDate,
                LeaveDays = model.LeaveDays,
                LeaveReason = model.LeaveReason,
                CreatedOn = DateTime.UtcNow,
                UpdatedOn = DateTime.UtcNow
            };

            var leaveAllocation = await _context.LeaveAllocations.Where(l => l.EmployeeId == model.UserId).FirstOrDefaultAsync();

            if (leaveAllocation != null)
            {
                leaveAllocation.NumberOfDays -= newApplication.LeaveDays;
            }

            _context.LeaveAllocations.Update(leaveAllocation);

            await _context.LeaveApplications.AddAsync(newApplication);
            await _context.SaveChangesAsync();

            return newApplication.Id;
        }

        public async Task<List<LeaveApplicationModel>> GetUserLeaveApplicationsById(string id)
        {
            return await _context.LeaveApplications.Where(l => l.UserId == id)
                .Select(application => new LeaveApplicationModel()
                {
                    Id = application.Id,
                    UserId = application.UserId,
                    LeaveTypeId = application.LeaveTypeId,
                    LeaveType = application.LeaveType.Type,
                    FromDate = application.FromDate,
                    LeaveDays = application.LeaveDays,
                    LeaveReason = application.LeaveReason,
                    DateApplied = application.CreatedOn

                }).ToListAsync();

        }

        public async Task<List<LeaveApplicationModel>> GetUserLeaveApplicationsByType(string userId, int typeId)
        {
            return await _context.LeaveApplications.Where(l => l.UserId == userId && l.LeaveTypeId == typeId)
                .Select(application => new LeaveApplicationModel()
                {
                    Id = application.Id,
                    UserId = application.UserId,
                    LeaveTypeId = application.LeaveTypeId,
                    LeaveType = application.LeaveType.Type,
                    FromDate = application.FromDate,
                    LeaveDays = application.LeaveDays,
                    LeaveReason = application.LeaveReason,
                    DateApplied = application.CreatedOn

                }).ToListAsync();

        }

        public async Task<List<LeaveTypeModel>> GetAllLeaveTypes()
        {
            return await _context.LeaveTypes
                .Select(type => new LeaveTypeModel()
                {
                    Id = type.Id,
                    Type = type.Type,
                    DefaultLeaveDays = type.DefaultLeaveDays
                }).ToListAsync();
        }

        public async Task<int> AddNewLeaveType(LeaveTypeModel model)
        {
            var newType = new LeaveType()
            {
                Type = model.Type,
                DefaultLeaveDays = model.DefaultLeaveDays
            };

            await _context.LeaveTypes.AddAsync(newType);
            await _context.SaveChangesAsync();

            return newType.Id;
        }

        public async Task<LeaveTypeModel> GetLeaveTypeById(int id)
        {
            var leaveType = await _context.LeaveTypes.FirstOrDefaultAsync(t => t.Id == id);

            var leaveTypeVM = new LeaveTypeModel()
            {
                Id = leaveType.Id,
                Type = leaveType.Type,
                DefaultLeaveDays = leaveType.DefaultLeaveDays
            };

            return leaveTypeVM;
        }

        public async Task<int> EditLeaveType(LeaveTypeModel model)
        {
            var type = await _context.LeaveTypes.FirstOrDefaultAsync(t => t.Id == model.Id);

            if(type != null)
            {
                type.Type = model.Type;
                type.DefaultLeaveDays = model.DefaultLeaveDays;
            }

            _context.LeaveTypes.Update(type);

            await _context.SaveChangesAsync();

            return type.Id;
        }

        public async Task<int> DeleteLeaveType(int id)
        {
            var type = await _context.LeaveTypes.FirstOrDefaultAsync(t => t.Id == id);            

            _context.LeaveTypes.Remove(type);

            await _context.SaveChangesAsync();

            return type.Id;
        }


    }
}
