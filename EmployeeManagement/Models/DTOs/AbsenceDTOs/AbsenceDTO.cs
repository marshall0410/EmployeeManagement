using EmployeeManagement.Models.DTOs.EmployeeDTOs;
using System;

namespace EmployeeManagement.Models.DTOs.AbsenceDTOs
{
    public class AbsenceDTO
    {
        public long Id { get; set; }
        public EmployeeDTO Employee { get; set; }
        public DateTime Date { get; set; }
        public AbsenceType AbsenceType { get; set; }
    }
}

