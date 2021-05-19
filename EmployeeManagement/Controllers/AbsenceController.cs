using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using EmployeeManagement.Data;
using EmployeeManagement.Models;
using EmployeeManagement.Models.Constants;
using EmployeeManagement.Models.DTOs.AbsenceDTOs;
using EmployeeManagement.Models.DTOs.EmployeeDTOs;
using EmployeeManagement.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Controllers
{    
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class AbsenceController : ControllerBase
    {        
        private readonly IAbsenceRepository _repository;
        public AbsenceController(IAbsenceRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Retrieves a list of Absences
        /// </summary>
        /// <returns>A list of Absences</returns>
        /// <response code="200">Returns a list of Absences</response>
        /// <response code="404">If theres no Absences</response>  
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<AbsenceDTO>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetAbsences()
        {
            var absenceDTOList = await _repository.GetAbsence();

            if (absenceDTOList == null)
            {
                return NotFound();
            }

            return Ok(absenceDTOList);
        }

        /// <summary>
        /// Retrieves a single Absence
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A single Absence</returns>
        /// <response code="200">Returns a single Absence</response>
        /// <response code="404">If Absence is not found</response>  
        [HttpGet("{id:int}", Name = "GetAbsence")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AbsenceDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetAbsence(long id)
        {
            var absence = await _repository.GetAbsence(id);

            if (absence == null)
            {
                return NotFound();
            }

            return Ok(absence);
        }

        /// <summary>
        /// Creates an Absence
        /// </summary>
        /// <param name="absenceDTO"></param>
        /// <response code="201">Created Succesfully</response>
        /// <response code="409">Only one absence code per employee per day</response>
        /// <response code="400">Bad Request</response>
        [HttpPost]
        [Authorize(Roles = Roles.Admin)]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(AbsenceDTO))]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateAbsence([FromBody] AbsenceCreateDTO absenceDTO)
        {
            if (absenceDTO == null)
            {
                return BadRequest(ModelState);
            }

            var absence = await _repository.CreateAbsence(absenceDTO);

            if (absence == null)
            {
                return Conflict("An employee may only have one absence per day.");
            }

            return CreatedAtAction(nameof(GetAbsence), new { id = absence.Id }, absence);            
        }

        /// <summary>
        /// Updates a single Absence
        /// </summary>
        /// <param name="id"></param>
        /// <param name="patchDoc"></param>
        /// <returns>Updates single Absence</returns>
        /// <response code="204">Absence was updated succesfully</response>
        /// <response code="400">Id in URL and json object must match</response>
        /// <response code="409">Concurrency exception was thrown</response>
        /// <remarks>
        /// Sample request:
        ///
        ///     PATCH /Absence/{id}
        ///     [
        ///          {
        ///             "op":"replace",
        ///             "path":"/AbsenceTypeId",
        ///             "value": 1
        ///          }
        ///     ]
        /// </remarks>
        
        [HttpPatch("{id:int}")]
        [Authorize(Roles = Roles.Admin)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdateAbsence([FromBody] JsonPatchDocument<AbsenceUpdateDTO> patchDoc, long id)
        {
            if (patchDoc == null)
            {
                return BadRequest();
            }

            var absence = await _repository.UpdateAbsence(patchDoc, id);

            if (absence == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        /// <summary>
        /// Removes a single Absence
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Removes a single Absence</returns>
        /// <response code="204">Absence deleted or never existed.</response>       
        
        [HttpDelete("{id:int}")]
        [Authorize(Roles = Roles.Admin)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> DeleteAbsence(int id)
        {
            await _repository.DeleteAbsence(id);
            return NoContent();
        }
    }
}