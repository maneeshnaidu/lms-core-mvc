using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManagement.Models
{
    public class LeaveApplicationModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int LeaveTypeId { get; set; }

        public DateTime FromDate { get; set; }

        [Display(Name = "Leave Days")]
        [Required(ErrorMessage = "Please enter your leave days.")]
        public decimal LeaveDays { get; set; }
        public string LeaveReason { get; set; }
        public ApplicationUser Employee { get; set; }
        public string LeaveType { get; set; }
        public DateTime DateApplied { get; set; }

        public List<UserLeaveModel> LeaveAllocations { get; set; }
    }
}
