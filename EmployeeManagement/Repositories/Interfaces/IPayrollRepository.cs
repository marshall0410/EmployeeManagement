using EmployeeManagement.Models;
using EmployeeManagement.Models.DTOs.PayrollDTOs;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagement.Repositories.Interfaces
{
    public interface IPayrollRepository
    {
        Task<IEnumerable<PayrollDTO>> GetPayroll();
        Task<PayrollDTO> GetPayroll(int id);
        Task<PayrollDTO> CreatePayroll(PayrollCreateDTO payrollDTO);
        Task<Payroll> UpdatePayroll(int id, JsonPatchDocument<Payroll> patchDoc);
    }
}