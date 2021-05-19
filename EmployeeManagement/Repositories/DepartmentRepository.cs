using AutoMapper;
using EmployeeManagement.Data;
using EmployeeManagement.Models;
using EmployeeManagement.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext _context;

        public DepartmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Department> CreateDepartment([FromBody] Department department)
        {
            var aType = await _context.Departments.AnyAsync(d => d.Name == department.Name.Trim().ToLower());

            if (aType == true)
            {
                return null;
            }

            department.Name.Trim().ToLower();
            _context.Departments.Add(department);
            await _context.SaveChangesAsync();
            return department;
        }

        public async Task<IEnumerable<Department>> GetDepartment()
        {
            return await _context.Departments.ToListAsync();
        }

        public async Task<Department> GetDepartment(int id)
        {
            return await _context.Departments.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Department> UpdateDepartment(Department department)
        {
            if (DepartmentExists(department.Name))
            {
                return null;
            }

            department.Name.Trim().ToLower();
            _context.Entry(department).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartmentExists(department.Id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return department;
        }
        private bool DepartmentExists(int id)
        {
            var aType = _context.Departments.Any(a => a.Id == id);

            if (aType == true)
            {
                return true;
            }
            return false;
        }

        private bool DepartmentExists(string name)
        {
            var aType = _context.Departments.Any(a => a.Name == name.ToLower().Trim());

            if (aType == true)
            {
                return true;
            }
            return false;
        }
    }
}       