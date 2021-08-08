using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManagement.Models
{
    public class LeaveAllocationModel
    {
        public int Id { get; set; }
        public decimal NumberOfDays { get; set; }
        public DateTime DateCreated { get; set; }
        public ApplicationUser Employee { get; set; }
        public string EmployeeId { get; set; }
        public string LeaveType { get; set; }
        public int LeaveTypeId { get; set; }
        public int Period { get; set; }
    }
}
