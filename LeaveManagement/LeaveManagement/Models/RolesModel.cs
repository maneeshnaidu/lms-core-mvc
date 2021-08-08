using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManagement.Models
{
    public class RolesModel : IdentityRole
    {
        public bool isSelected { get; set; }
    }
}
