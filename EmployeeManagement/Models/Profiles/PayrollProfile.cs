using AutoMapper;
using EmployeeManagement.Models.DTOs.PayrollDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models.Profiles
{
    public class PayrollProfile : Profile
    {
        public PayrollProfile()
        {
            CreateMap<Payroll, PayrollDTO>();
            CreateMap<PayrollCreateDTO, Payroll>();
        }
    }
}
