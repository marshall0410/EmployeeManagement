using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class Employee : IdentityUser
    {
        public int? DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
