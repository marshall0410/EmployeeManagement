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
    public class AbsenceTypeRepository : IAbsenceTypeRepository
    {
        private readonly ApplicationDbContext _context;

        public AbsenceTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<AbsenceType> CreateAbsenceType([FromBody] AbsenceType absenceType)
        {
            var aType = await _context.AbsenceTypes.AnyAsync(a => a.Name == absenceType.Name.Trim().ToLower());

            if (aType == true)
            {
                return null;
            }

            absenceType.Name.Trim().ToLower();
            _context.AbsenceTypes.Add(absenceType);
            await _context.SaveChangesAsync();
            return absenceType;
        }

        public async Task<IEnumerable<AbsenceType>> GetAbsenceType()
        {
            return await _context.AbsenceTypes.ToListAsync();
        }

        public async Task<AbsenceType> GetAbsenceType(int id)
        {
            return await _context.AbsenceTypes.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<AbsenceType> UpdateAbsenceType(AbsenceType absenceType)
        {
            if (AbsenceTypeExists(absenceType.Name))
            {
                return null;
            }

            absenceType.Name.Trim().ToLower();
            _context.Entry(absenceType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AbsenceTypeExists(absenceType.Id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return absenceType;
        }
        private bool AbsenceTypeExists(int id)
        {
            var aType = _context.AbsenceTypes.Any(a => a.Id == id);

            if (aType == true)
            {
                return true;
            }
            return false;
        }

        private bool AbsenceTypeExists(string name)
        {
            var aType = _context.AbsenceTypes.Any(a => a.Name == name.ToLower().Trim());

            if (aType == true)
            {
                return true;
            }
            return false;
        }
    }
}       