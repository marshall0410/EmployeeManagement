using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EmployeeManagement.Models;
using EmployeeManagement.Models.Auth;
using EmployeeManagement.Models.DTOs.EmployeeDTOs;

namespace EmployeeManagement.Models.Profiles {
    public class EmployeeProfile : Profile {
        public EmployeeProfile () {
            CreateMap<Employee, EmployeeDTO> ().ReverseMap();
            CreateMap<EmployeeUpdateDTO, Employee>().ReverseMap();
            CreateMap<UserRegistration, Employee>();
        }
    }
}