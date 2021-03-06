using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class Salary
    {
        public int Id { get; set; }
        [Required]
        public float AnnualSalary { get; set; }
        public Employee Employee { get; set; }
        [Required]
        public string EmployeeId { get; set; }
        public float Allowance { get; set; }
        public float Tax { get; set; }
        public float GrossSalary { get; set; }
        public float NetSalary { get; set; }
    }
}
