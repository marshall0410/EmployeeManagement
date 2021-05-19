using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EmployeeManagement.Data;
using EmployeeManagement.Models;
using EmployeeManagement.Models.DTOs.EmployeeDTOs;
using EmployeeManagement.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Controllers 
{
    [Produces ("application/json")]
    [Route ("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase 
    {

        private readonly IEmployeeRepository _repository;

        public EmployeeController(IEmployeeRepository repository) 
        {
            _repository = repository;
        }

        /// <summary>
        /// Retrieves a list of Employees
        /// </summary>
        /// <returns>A list of Employees</returns>
        /// <response code="200">Returns a list of employees</response>
        /// <response code="404">If theres no employees</response>  
        [HttpGet]
        [ProducesResponseType (StatusCodes.Status200OK, Type = typeof (List<EmployeeDTO>))]
        [ProducesResponseType (StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetEmployees () {
            var DTOList = await _repository.GetEmployees();
            if (DTOList == null)
            {
                return NotFound();
            }
            return Ok(DTOList);
        }

        /// <summary>
        /// Retrieves a single Employee
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A single Employee</returns>
        /// <response code="200">Returns a single Employee</response>
        /// <response code="404">If employee is not found</response>  
        [HttpGet ("{id}", Name = "GetEmployee")]
        [ProducesResponseType (StatusCodes.Status200OK, Type = typeof (EmployeeDTO))]
        [ProducesResponseType (StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetEmployee (string id) {
            var employee = await _repository.GetEmployee(id);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        /// <summary>
        /// Updates a single Employee
        /// </summary>
        /// <param name="id"></param>
        /// <param name="patchDoc"></param>
        /// <returns>Updates single Employee</returns>
        /// <response code="204">Employee was updated succesfully</response>
        /// <response code="400">Must send JSON body with correct format.</response>
        /// <response code="404">Unable to locate requested resource</response>
        /// <remarks>
        /// Sample request:
        ///
        ///     PATCH /Employee/{id}
        ///     [
        ///         {
        ///             "op":"replace",
        ///             "path":"/AbsenceTypeId",
        ///             "value": 2
        ///          }
        ///     ]
        /// </remarks>
        [ProducesResponseType (StatusCodes.Status204NoContent)]
        [ProducesResponseType (StatusCodes.Status400BadRequest)]
        [ProducesResponseType (StatusCodes.Status404NotFound)]
        [HttpPatch ("{id}")]
        public async Task<ActionResult> UpdateEmployee (string id, [FromBody] JsonPatchDocument<EmployeeUpdateDTO> patchDoc) 
        {
            if (patchDoc == null)
            {
                return BadRequest();
            }

            var grievance = await _repository.UpdateEmployee(id, patchDoc);

            if (grievance == null)
            {
                return NotFound();
            }
            return NoContent();
        }

    }
}