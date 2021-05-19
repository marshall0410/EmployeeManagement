using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models {
    public class Absence {
        public long Id { get; set; }
        [Required]
        public string EmployeeId { get; set; }
        public Employee Employee { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public int AbsenceTypeId { get; set; }
        public AbsenceType AbsenceType { get; set; }
    }
}