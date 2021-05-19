using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models.Auth
{
    public class UserLogin
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}