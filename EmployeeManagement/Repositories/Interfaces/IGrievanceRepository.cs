using EmployeeManagement.Models;
using EmployeeManagement.Models.DTOs.GrievanceDTOs;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Repositories.Interfaces
{
    public interface IGrievanceRepository
    {
        Task<IEnumerable<GrievanceDTO>> GetGrievances();
        Task<GrievanceDTO> GetGrievance(int id);
        Task<GrievanceDTO> CreateGrievance(GrievanceCreateDTO grievance);
        Task<GrievanceDTO> UpdateGrievance(int id, JsonPatchDocument<GrievanceUpdateDTO> patchDoc);        
    }
}
