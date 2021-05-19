using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models.DTOs.AbsenceDTOs
{
    public class AbsenceUpdateDTO
    {
        [Required]
        public int AbsenceTypeId { get; set; }
    }
}
