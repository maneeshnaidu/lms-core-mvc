using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManagement.Models
{
    public class LeaveTypeModel
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public decimal DefaultLeaveDays { get; set; }
    }
}
