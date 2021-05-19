using EmployeeManagement.Models;
using EmployeeManagement.Models.DTOs.AbsenceDTOs;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Repositories.Interfaces
{
    public interface IAbsenceRepository
    {
        Task<IEnumerable<AbsenceDTO>> GetAbsence();
        Task<AbsenceDTO> GetAbsence(long id);
        Task<AbsenceDTO> CreateAbsence(AbsenceCreateDTO absenceDTO);
        Task<Absence> UpdateAbsence(JsonPatchDocument<AbsenceUpdateDTO> patchDoc, long id);
        Task<Absence> DeleteAbsence(long id);
    }
}
