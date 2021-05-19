using AutoMapper;
using EmployeeManagement.Models.DTOs.AbsenceTypeDTOs;

namespace EmployeeManagement.Models.Profiles
{
    public class AbsenceTypeProfile : Profile
    {
        public AbsenceTypeProfile()
        {
            CreateMap<AbsenceTypeCreateDTO, AbsenceType>();
        }
    }
}