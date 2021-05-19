using AutoMapper;
using EmployeeManagement.Data;
using EmployeeManagement.Models;
using EmployeeManagement.Models.DTOs.EmployeeDTOs;
using EmployeeManagement.Repositories.Interfaces;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public EmployeeRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EmployeeDTO>> GetEmployees()
        {
            var employees = await _context.Employees
                .Include(emp => emp.Department)
                .ToListAsync();

            if (employees == null)
            {
                return null;
            }

            var empDTOList = new List<EmployeeDTO>();

            foreach (Employee employee in employees)
            {
                empDTOList.Add(_mapper.Map<EmployeeDTO>(employee));
            }

            return empDTOList;
        }
        public async Task<EmployeeDTO> GetEmployee(string id)
        {

            var employee = await _context.Employees.Include(e => e.Department).FirstOrDefaultAsync(e => e.Id == id);

            if (employee == null)
            {
                return null;
            }

            var empDTO = _mapper.Map<EmployeeDTO>(employee);

            return empDTO;
        }

        public async Task<EmployeeDTO> UpdateEmployee(string id, JsonPatchDocument<EmployeeUpdateDTO> patchDoc)
        {
            var employeeFromDb = await _context.Employees.FirstOrDefaultAsync(g => g.Id == id);

            if (employeeFromDb == null)
            {
                return null;
            }

            var employeeDTO = _mapper.Map<EmployeeUpdateDTO>(employeeFromDb);
            patchDoc.ApplyTo(employeeDTO);
            _mapper.Map(employeeDTO, employeeFromDb);
            await _context.SaveChangesAsync();
            return _mapper.Map<EmployeeDTO>(employeeFromDb);
        }

    }
}
