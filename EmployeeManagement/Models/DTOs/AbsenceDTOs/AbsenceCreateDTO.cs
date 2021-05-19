using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models.DTOs.AbsenceDTOs
{
    public class AbsenceCreateDTO
    {
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public int AbsenceTypeId { get; set; }
        [Required]
        public string EmployeeId { get; set; }
    }
}