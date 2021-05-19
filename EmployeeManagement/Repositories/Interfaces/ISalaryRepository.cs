using EmployeeManagement.Models;
using EmployeeManagement.Models.DTOs.SalaryDTOs;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagement.Repositories.Interfaces
{
    public interface ISalaryRepository
    {
        Task<IEnumerable<SalaryDTO>> GetSalary();
        Task<SalaryDTO> GetSalary(int id);
        Task<SalaryDTO> CreateSalary(SalaryCreateDTO salaryDTO);
        Task<Salary> UpdateSalary(int id, JsonPatchDocument<Salary> patchDoc);
    }
}