using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models.DTOs.AbsenceTypeDTOs {
    public class AbsenceTypeCreateDTO {
        [Required]
        public string Name { get; set; }
    }
}