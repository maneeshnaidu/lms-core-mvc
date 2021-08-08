using LeaveManagement.Data;
using LeaveManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManagement.Repository
{
    public class LeaveAllocationRepository : ILeaveAllocationRepository
    {
        private readonly ApplicationDbContext _context = null;
        private readonly ILeaveRepository _leaveRepository = null;

        public LeaveAllocationRepository(ApplicationDbContext context, ILeaveRepository leaveRepository)
        {
            _context = context;
            _leaveRepository = leaveRepository;
        }

        public async Task<bool> CheckAllocation(int leaveTypeId, string employeeId)
        {
            var period = DateTime.Now.Year;
            var allocations = await FindAll();
            return allocations.Where(q => q.EmployeeId == employeeId
                                        && q.LeaveTypeId == leaveTypeId
                                        && q.Period == period)
                .Any();
        }

        public async Task<bool> Create(LeaveAllocation entity)
        {
            await _context.LeaveAllocations.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(LeaveAllocation entity)
        {
            _context.LeaveAllocations.Remove(entity);
            return await Save();
        }

        public async Task<ICollection<LeaveAllocation>> FindAll()
        {
            var LeaveAllocations = await _context.LeaveAllocations
                .Include(q => q.LeaveType)
                .Include(q => q.Employee)
                .ToListAsync();
            return LeaveAllocations;
        }

        public async Task<LeaveAllocation> FindById(int id)
        {
            var LeaveAllocation = await _context.LeaveAllocations
                .Include(q => q.LeaveType)
                .Include(q => q.Employee)
                .FirstOrDefaultAsync(q => q.Id == id);
            return LeaveAllocation;
        }

        public async Task<List<LeaveAllocationModel>> GetLeaveAllocationsByEmployee(string employeeid)
        {
            var period = DateTime.Now.Year;
            var allocations = await FindAll();
            return allocations.Where(q => q.EmployeeId == employeeid && q.Period == period)
                .Select(leaveAllocations => new LeaveAllocationModel()
                {
                    Id = leaveAllocations.Id,
                    NumberOfDays = leaveAllocations.NumberOfDays,
                    Employee = leaveAllocations.Employee,
                    LeaveTypeId = leaveAllocations.LeaveType.Id,
                    LeaveType = leaveAllocations.LeaveType.Type,
                    DateCreated = leaveAllocations.DateCreated,
                    Period = leaveAllocations.Period

                })
                    .ToList();

        }

        public async Task<LeaveAllocation> GetLeaveAllocationsByEmployeeAndType(string employeeid, int leavetypeid)
        {
            var period = DateTime.Now.Year;
            var allocations = await FindAll();
            return allocations.FirstOrDefault(q => q.EmployeeId == employeeid
                                                    && q.Period == period
                                                    && q.LeaveTypeId == leavetypeid);
        }

        public async Task<bool> isExists(int id)
        {
            var exists = await _context.LeaveAllocations.AnyAsync(q => q.Id == id);
            return exists;
        }

        public async Task<bool> Save()
        {
            var changes = await _context.SaveChangesAsync();
            return changes > 0;
        }

        public async Task<bool> Update(LeaveAllocation entity)
        {
            _context.LeaveAllocations.Update(entity);
            return await Save();
        }

        public async Task SetLeave(string userId)
        {
            var leaveTypes = await _leaveRepository.GetAllLeaveTypes();
            var period = DateTime.Now.Year;

            foreach (var type in leaveTypes)
            {
                var allocation = new LeaveAllocation()
                {
                    EmployeeId = userId,
                    LeaveTypeId = type.Id,
                    NumberOfDays = type.DefaultLeaveDays,
                    Period = DateTime.Now.Year,
                    DateCreated = DateTime.Now
                };

                await _context.LeaveAllocations.AddAsync(allocation);
                await _context.SaveChangesAsync();
            }
        }
    }
}
