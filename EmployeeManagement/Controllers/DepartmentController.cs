using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EmployeeManagement.Data;
using EmployeeManagement.Models;
using EmployeeManagement.Models.Constants;
using EmployeeManagement.Models.DTOs;
using EmployeeManagement.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Controllers {
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase 
    {
        private readonly IDepartmentRepository _repository;

        public DepartmentController(IDepartmentRepository repository) 
        {
            _repository = repository;
        }

        /// <summary>
        /// Retrieves a list of Departments
        /// </summary>
        /// <returns>A list of Departments</returns>
        /// <response code="200">Returns a list of Departments</response>
        /// <response code="404">If theres no Departments</response>  
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Department>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetDepartments() 
        {
            var departments = await _repository.GetDepartment();

            if(departments == null) 
            {
                return NotFound();
            }

            return Ok(departments);
        }

        /// <summary>
        /// Retrieves a single Department
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A single Department</returns>
        /// <response code="200">Returns a single Department</response>
        /// <response code="404">If Department is not found</response>  
        [HttpGet("{id:int}", Name = "GetDepartment")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Department))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetDepartment(int id) 
        {
            var department = await _repository.GetDepartment(id);

            if(department == null) 
            {
                return NotFound();
            }

            return Ok(department);
        }

        /// <summary>
        /// Creates an Department
        /// </summary>
        /// <param name="department"></param>
        /// <response code="201">Created Succesfully</response>
        /// <response code="409">Already Exists</response>
        /// <response code="400">Bad Request</response>
        [HttpPost]
        [Authorize(Roles = Roles.Admin)]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Department))]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateDepartment([FromBody] Department department) 
        {
            if(department == null) 
            {
                return BadRequest();
            }

            var aType = await _repository.CreateDepartment(department); 
                        
            if(aType == null) 
            {
                return Conflict();
            }
            
            return CreatedAtAction(nameof(GetDepartment), new { id = department.Id }, department);
        }

        /// <summary>
        /// Updates a single Department
        /// </summary>
        /// <param name="id"></param>
        /// <param name="department"></param>
        /// <returns>Updates single Department</returns>
        /// <response code="204">Department was updated succesfully</response>
        /// <response code="400">Id in URL and json object must match</response>
        /// <response code="404">Resource doesnt exist or Attempted to create resource with duplicate name.</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Roles = Roles.Admin)]
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateDepartment(int id, [FromBody] Department department) 
        {
            if(department == null || department.Id != id) 
            {
                return BadRequest();
            }

            var aType = await _repository.UpdateDepartment(department);

            if (aType == null)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}