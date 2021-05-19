using AutoMapper;
using EmployeeManagement.Data;
using EmployeeManagement.Models;
using EmployeeManagement.Models.DTOs.PayrollDTOs;
using EmployeeManagement.Repositories.Interfaces;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Repositories
{
    public class PayrollRepository : IPayrollRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public PayrollRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PayrollDTO>> GetPayroll()
        {
            var payrollList = await _context.Payroll
                .Include(e => e.Employee)
                .ThenInclude(d => d.Department)
                .ToListAsync();

            if (payrollList == null)
            {
                return null;
            }

            var payrollDTOlist = new List<PayrollDTO>();

            foreach (Payroll payroll in payrollList)
            {
                payrollDTOlist.Add(_mapper.Map<PayrollDTO>(payroll));
            }


            return payrollDTOlist;

        }
        public async Task<PayrollDTO> GetPayroll(int id)
        {
            var payroll = await _context.Payroll
                .Include(e => e.Employee)
                .ThenInclude(d => d.Department)
                .FirstOrDefaultAsync(g => g.Id == id);

            if (payroll == null)
            {
                return null;
            }

            return _mapper.Map<PayrollDTO>(payroll);
        }
        public async Task<PayrollDTO> CreatePayroll(PayrollCreateDTO payrollDTO)
        {
            if (payrollDTO == null)
            {
                return null;
            }

            var payroll = _mapper.Map<Payroll>(payrollDTO);
            _context.Payroll.Add(payroll);
            await _context.SaveChangesAsync();
            return _mapper.Map<PayrollDTO>(payroll);
            }
        
        public async Task<Payroll> UpdatePayroll(int id, JsonPatchDocument<Payroll> patchDoc)
        {
            var payroll = await _context.Payroll.FirstOrDefaultAsync(g => g.Id == id);

            if (payroll == null)
            {
                return null;
            }

            patchDoc.ApplyTo(payroll);
            await _context.SaveChangesAsync();

            return payroll;
        }
    }
}
