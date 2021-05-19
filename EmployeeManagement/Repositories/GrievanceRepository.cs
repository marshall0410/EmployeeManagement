using AutoMapper;
using EmployeeManagement.Data;
using EmployeeManagement.Models;
using EmployeeManagement.Models.DTOs.GrievanceDTOs;
using EmployeeManagement.Repositories.Interfaces;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Repositories
{
    public class GrievanceRepository : IGrievanceRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GrievanceRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GrievanceDTO>> GetGrievances()
        {
            var grievances = await _context.Grievances
                .Include(e => e.Employee)
                .Include(r => r.Respondant)
                .ThenInclude(d => d.Department)
                .ToListAsync();

            if (grievances == null)
            {
                return null;
            }

            var DTOlist = new List<GrievanceDTO>();

            foreach (Grievance grievance in grievances)
            {
                DTOlist.Add(_mapper.Map<GrievanceDTO>(grievance));
            }

            return DTOlist;

        }
        public async Task<GrievanceDTO> GetGrievance(int id)
        {
            var grievance = await _context.Grievances
                .Include(e => e.Employee)
                .Include(r => r.Respondant)
                .ThenInclude(d => d.Department)
                .FirstOrDefaultAsync(g => g.Id == id);

            if (grievance == null)
            {
                return null;
            }

            var grievanceDTO = _mapper.Map<GrievanceDTO>(grievance);

            return grievanceDTO;
        }
        public async Task<GrievanceDTO> CreateGrievance(GrievanceCreateDTO grievance)
        {
            if (grievance == null)
            {
                return null;
            }

            var grievanceObj = _mapper.Map<Grievance>(grievance);
            grievanceObj.DateSubmitted = DateTime.Now;
            _context.Grievances.Add(grievanceObj);
            await _context.SaveChangesAsync();
            return _mapper.Map<GrievanceDTO>(grievanceObj);
            }
        
        public async Task<GrievanceDTO> UpdateGrievance(int id, JsonPatchDocument<GrievanceUpdateDTO> patchDoc)
        {
            var grievanceFromDb = await _context.Grievances.FirstOrDefaultAsync(g => g.Id == id);

            if (grievanceFromDb == null)
            {
                return null;
            }

            var grievanceDTO = _mapper.Map<GrievanceUpdateDTO>(grievanceFromDb);
            patchDoc.ApplyTo(grievanceDTO);
            _mapper.Map(grievanceDTO, grievanceFromDb);
            grievanceFromDb.DateAnswered = DateTime.Now;
            return _mapper.Map<GrievanceDTO>(grievanceFromDb);
        }

    }
}
