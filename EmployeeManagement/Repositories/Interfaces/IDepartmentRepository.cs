using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Repositories.Interfaces
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Department>> GetDepartment();
        Task<Department> GetDepartment(int id);
        Task<Department> CreateDepartment(Department absenceType);
        Task<Department> UpdateDepartment(Department absenceType);
    }
}
