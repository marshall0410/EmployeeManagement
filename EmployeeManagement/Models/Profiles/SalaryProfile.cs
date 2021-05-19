using AutoMapper;
using EmployeeManagement.Models.DTOs.SalaryDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models.Profiles
{
    public class SalaryProfile : Profile
    {
        public SalaryProfile()
        {
            CreateMap<Salary, SalaryDTO>();
            CreateMap<SalaryCreateDTO, Salary>();
        }
    }
}
