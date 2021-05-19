using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class Grievance
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public DateTime DateSubmitted { get; set; }
        public DateTime DateAnswered { get; set; }
        public string RespondentBody { get; set; }
        public string EmployeeId { get; set; }
        public string RespondantId { get; set; }
        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }
        [ForeignKey("RespondantId")]
        public Employee Respondant { get; set; }
    }
}
