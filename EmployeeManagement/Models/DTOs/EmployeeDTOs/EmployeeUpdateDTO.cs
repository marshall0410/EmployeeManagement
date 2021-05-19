using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models.DTOs.EmployeeDTOs 
{
    public class EmployeeUpdateDTO 
    {
        public string Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        //[Required]
        //public string ConcurrencyStamp { get; set; }

        [Required]
        public int DepartmentId { get; set; }
    }
}