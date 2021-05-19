using AutoMapper;
using EmployeeManagement.Data;
using EmployeeManagement.Models;
using EmployeeManagement.Models.DTOs.SalaryDTOs;
using EmployeeManagement.Repositories.Interfaces;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Repositories
{
    public class SalaryRepository : ISalaryRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public SalaryRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SalaryDTO>> GetSalary()
        {
            var salaryList = await _context.Salaries
                .Include(e => e.Employee)
                .ThenInclude(d => d.Department)
                .ToListAsync();

            if (salaryList == null)
            {
                return null;
            }

            var salaryDTOlist = new List<SalaryDTO>();

            foreach (Salary salary in salaryList)
            {
                salaryDTOlist.Add(_mapper.Map<SalaryDTO>(salary));
            }


            return salaryDTOlist;

        }
        public async Task<SalaryDTO> GetSalary(int id)
        {
            var salary = await _context.Salaries
                .Include(e => e.Employee)
                .ThenInclude(d => d.Department)
                .FirstOrDefaultAsync(g => g.Id == id);

            if (salary == null)
            {
                return null;
            }

            return _mapper.Map<SalaryDTO>(salary);
        }
        public async Task<SalaryDTO> CreateSalary(SalaryCreateDTO salaryDTO)
        {
            if (salaryDTO == null)
            {
                return null;
            }

            var salary = _mapper.Map<Salary>(salaryDTO);
            _context.Salaries.Add(salary);
            await _context.SaveChangesAsync();
            return _mapper.Map<SalaryDTO>(salary);
            }
        
        public async Task<Salary> UpdateSalary(int id, JsonPatchDocument<Salary> patchDoc)
        {
            var salary = await _context.Salaries.FirstOrDefaultAsync(g => g.Id == id);

            if (salary == null)
            {
                return null;
            }

            patchDoc.ApplyTo(salary);
            await _context.SaveChangesAsync();

            return salary;
        }
    }
}
