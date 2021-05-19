using EmployeeManagement.Models.DTOs.EmployeeDTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models.DTOs.SalaryDTOs
{
    public class SalaryDTO
    {
        public int Id { get; set; }
        [Required]
        public float AnnualSalary { get; set; }
        public EmployeeDTO Employee { get; set; }
        [Required]
        public string EmployeeId { get; set; }
        public float Allowance { get; set; }
        public float Tax { get; set; }
        public float GrossSalary { get; set; }
        public float NetSalary { get; set; }
    }
}
