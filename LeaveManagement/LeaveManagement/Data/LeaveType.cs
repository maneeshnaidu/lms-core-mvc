using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManagement.Data
{
    public class LeaveType
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public decimal DefaultLeaveDays { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
