using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models.DTOs.GrievanceDTOs
{
    public class GrievanceUpdateDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string RespondentBody { get; set; }
        [Required]
        public string RespondantId { get; set; }
    }
}
