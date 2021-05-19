using AutoMapper;
using EmployeeManagement.Models.DTOs.AbsenceDTOs;

namespace EmployeeManagement.Models.Profiles
{
    public class AbsenceProfile : Profile
    {
        public AbsenceProfile()
        {
            CreateMap<AbsenceCreateDTO, Absence>();
            CreateMap<Absence, AbsenceDTO>();
        }
    }
}
