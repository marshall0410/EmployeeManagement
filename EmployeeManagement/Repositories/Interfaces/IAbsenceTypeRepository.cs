using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Repositories.Interfaces
{
    public interface IAbsenceTypeRepository
    {
        Task<IEnumerable<AbsenceType>> GetAbsenceType();
        Task<AbsenceType> GetAbsenceType(int id);
        Task<AbsenceType> CreateAbsenceType(AbsenceType absenceType);
        Task<AbsenceType> UpdateAbsenceType(AbsenceType absenceType);
    }
}
