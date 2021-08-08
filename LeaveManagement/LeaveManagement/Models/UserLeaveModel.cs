using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManagement.Models
{
    public class UserLeaveModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Employee { get; set; }
        public int LeaveTypeId { get; set; }
        public string LeaveType { get; set; }
        public decimal RemainingLeaveDays { get; set; }
    }
}
