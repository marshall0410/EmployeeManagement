using AutoMapper;
using EmployeeManagement.Data;
using EmployeeManagement.Models;
using EmployeeManagement.Models.DTOs.AbsenceDTOs;
using EmployeeManagement.Repositories.Interfaces;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Repositories
{
    public class AbsenceRepository : IAbsenceRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public AbsenceRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<AbsenceDTO> CreateAbsence(AbsenceCreateDTO absenceDTO)
        {
            var absenceExists = await _context.Absences.AnyAsync(a => a.Date.Date == absenceDTO.Date.Date && a.EmployeeId == absenceDTO.EmployeeId);

            if (absenceExists == true)
            {
                return null;
            }

            var absence = _mapper.Map<Absence>(absenceDTO);
            
            _context.Absences.Add(absence);
            await _context.SaveChangesAsync();

            //return _mapper.Map<AbsenceDTO>(absence);
            return await GetAbsence(absence.Id);
        }

        public async Task<IEnumerable<AbsenceDTO>> GetAbsence()
        {
            var absences = await _context.Absences
                .Include(e => e.Employee)
                .ThenInclude(d => d.Department)
                .Include(a => a.AbsenceType)
                .ToListAsync();

            if (absences == null)
            {
                return null;
            }

            var absenceDTOList = new List<AbsenceDTO>();

            foreach (var absence in absences)
            {
                absenceDTOList.Add(_mapper.Map<AbsenceDTO>(absence));
            }

            return absenceDTOList;
        }

        public async Task<AbsenceDTO> GetAbsence(long id)
        {
            var absence = await _context.Absences
               .Include(e => e.Employee)
               .ThenInclude(d => d.Department)
               .Include(a => a.AbsenceType)
               .FirstOrDefaultAsync(a => a.Id == id);

            if (absence == null)
            {
                return null;
            }

            return _mapper.Map<AbsenceDTO>(absence);
        }

        public async Task<Absence> UpdateAbsence(JsonPatchDocument<AbsenceUpdateDTO> patchDoc, long id)
        {
            var absenceFromDb = await _context.Absences.FirstOrDefaultAsync(g => g.Id == id);

            if (absenceFromDb == null)
            {
                return null;
            }

            var absenceDTO = _mapper.Map<AbsenceUpdateDTO>(absenceFromDb);
            patchDoc.ApplyTo(absenceDTO);
            _mapper.Map(absenceDTO, absenceFromDb);
            await _context.SaveChangesAsync();
            return absenceFromDb;
        }

        public async Task<Absence> DeleteAbsence(long id)
        {
            var absence = await _context.Absences.FindAsync(id);

            if (absence == null)
            {
                return null;
            }

            _context.Absences.Remove(absence);
            await _context.SaveChangesAsync();
            return null;
        }
    }
}
