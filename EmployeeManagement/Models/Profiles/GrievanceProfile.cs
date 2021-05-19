using AutoMapper;
using EmployeeManagement.Models.DTOs.GrievanceDTOs;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models.Profiles
{
    public class GrievanceProfile : Profile
    {
        public GrievanceProfile()
        {
            CreateMap<Grievance, GrievanceDTO>();
            CreateMap<GrievanceCreateDTO, Grievance>();
            CreateMap<GrievanceUpdateDTO, Grievance>().ReverseMap();
            //CreateMap<JsonPatchDocument<GrievanceUpdateDTO>, JsonPatchDocument<Grievance>>();
            //CreateMap<Operation<GrievanceUpdateDTO>, Operation<Grievance>>();
        }
    }
}
