using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models {
    public class AbsenceType {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}