using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class Payroll
    {
        public long Id { get; set; }
        [Required]
        [Range(1, 12,
            ErrorMessage = "Value for must be between 1 - 12.")]
        public sbyte Month { get; set; }
        [Range(1, 9999, 
            ErrorMessage = "Please enter valid year.")]
        [Required]
        public short Year { get; set; }
        [Required]
        public float PaidSalary { get; set; }
        [Required]
        public string EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
