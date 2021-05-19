using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models.DTOs.GrievanceDTOs
{
    public class GrievanceCreateDTO
    {
        [Required]
        public string Body { get; set; }
        [Required]
        public string EmployeeId { get; set; }        
    }
}
