using EmployeeManagement.Models.DTOs.EmployeeDTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models.DTOs.GrievanceDTOs
{
    public class GrievanceDTO
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public DateTime DateSubmitted { get; set; }
        public DateTime DateAnswered { get; set; }
        public string RespondentBody { get; set; }
        public string EmployeeId { get; set; }
        public string RespondantId { get; set; }
        [ForeignKey("EmployeeId")]
        public EmployeeDTO Employee { get; set; }
        [ForeignKey("RespondantId")]
        public EmployeeDTO Respondant { get; set; }
    }
}
