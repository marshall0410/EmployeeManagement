using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EmployeeManagement.Data;
using EmployeeManagement.Models;
using EmployeeManagement.Models.Constants;
using EmployeeManagement.Models.DTOs;
using EmployeeManagement.Models.DTOs.AbsenceTypeDTOs;
using EmployeeManagement.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Controllers {
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class AbsenceTypeController : ControllerBase 
    {
        private readonly IAbsenceTypeRepository _repository;

        public AbsenceTypeController(IAbsenceTypeRepository repository) 
        {
            _repository = repository;
        }

        /// <summary>
        /// Retrieves a list of AbsenceTypes
        /// </summary>
        /// <returns>A list of AbsenceTypes</returns>
        /// <response code="200">Returns a list of AbsenceTypes</response>
        /// <response code="404">If theres no AbsenceTypes</response>  
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<AbsenceType>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetAbsenceTypes() 
        {
            var absenceTypes = await _repository.GetAbsenceType();

            if(absenceTypes == null) 
            {
                return NotFound();
            }

            return Ok(absenceTypes);
        }

        /// <summary>
        /// Retrieves a single AbsenceType
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A single AbsenceType</returns>
        /// <response code="200">Returns a single AbsenceType</response>
        /// <response code="404">If AbsenceType is not found</response>  
        [HttpGet("{id:int}", Name = "GetAbsenceType")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AbsenceType))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetAbsenceType(int id) 
        {
            var absenceType = await _repository.GetAbsenceType(id);

            if(absenceType == null) 
            {
                return NotFound();
            }

            return Ok(absenceType);
        }

        /// <summary>
        /// Creates an AbsenceType
        /// </summary>
        /// <param name="absenceType"></param>
        /// <response code="201">Created Succesfully</response>
        /// <response code="409">Already Exists</response>
        /// <response code="400">Bad Request</response>
        [HttpPost]
        [Authorize(Roles = Roles.Admin)]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(AbsenceType))]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateAbsenceType([FromBody] AbsenceType absenceType) 
        {
            if(absenceType == null) 
            {
                return BadRequest();
            }

            var aType = await _repository.CreateAbsenceType(absenceType); 
                        
            if(aType == null) 
            {
                return Conflict();
            }
            
            return CreatedAtAction(nameof(GetAbsenceType), new { id = absenceType.Id }, absenceType);
        }

        /// <summary>
        /// Updates a single AbsenceType
        /// </summary>
        /// <param name="id"></param>
        /// <param name="absenceType"></param>
        /// <returns>Updates single AbsenceType</returns>
        /// <response code="204">AbsenceType was updated succesfully</response>
        /// <response code="400">Id in URL and json object must match</response>
        /// <response code="404">Resource doesnt exist or Attempted to create resource with duplicate name.</response>
        [HttpPut("{id}")]
        [Authorize(Roles = Roles.Admin)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]        
        public async Task<ActionResult> UpdateAbsenceType(int id, [FromBody] AbsenceType absenceType) 
        {
            if(absenceType == null || absenceType.Id != id) 
            {
                return BadRequest();
            }

            var aType = await _repository.UpdateAbsenceType(absenceType);

            if (aType == null)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}