using EmployeeManagement.Models.DTOs.EmployeeDTOs;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<EmployeeDTO>> GetEmployees();
        Task<EmployeeDTO> GetEmployee(string id);
        Task<EmployeeDTO> UpdateEmployee(string id, JsonPatchDocument<EmployeeUpdateDTO> patchDoc);
    }
}
