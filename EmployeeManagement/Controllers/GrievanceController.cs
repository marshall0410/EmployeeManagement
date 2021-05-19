using AutoMapper;
using EmployeeManagement.Data;
using EmployeeManagement.Models;
using EmployeeManagement.Models.Constants;
using EmployeeManagement.Models.DTOs.GrievanceDTOs;
using EmployeeManagement.Repositories;
using EmployeeManagement.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class GrievanceController : ControllerBase
    {
        private readonly IGrievanceRepository _repository;
         public GrievanceController(IGrievanceRepository repository)
        {
            _repository = repository;
        }


        /// <summary>
        /// Retrieves an array of Grievances 
        /// </summary>
        /// <returns>A list of Grievances</returns>
        /// <response code="200"></response>
        /// <response code="404"></response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GrievanceDTO>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetGrievances()
        {
            var DTOList = await _repository.GetGrievances();
            if(DTOList == null)
            {
                return NotFound();
            }
            return Ok(DTOList);
        }

        /// <summary>
        /// Retrieves an array of Grievances 
        /// </summary>
        /// <returns>A list of Grievances</returns>
        /// <param name="id"></param>
        /// <response code="200"></response>
        /// <response code="404"></response>
        [HttpGet("{id:int}", Name = "GetGrievance")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GrievanceDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetGrievance(int id)
        {
            var grievance = await _repository.GetGrievance(id);

            if (grievance == null)
            {
                return NotFound();
            }

            return Ok(grievance);
        }

        /// <summary>
        /// Updates a single Grievance
        /// </summary>
        /// <param name="grievanceDTO"></param>
        /// <returns>Creates a single Grievance</returns>
        /// <response code="201">Grievance was updated succesfully</response>
        [HttpPost]
        [Authorize(Roles = Roles.Admin)]
        [ProducesResponseType(StatusCodes.Status201Created, Type=typeof(GrievanceDTO))]
        public async Task<ActionResult> CreateGrievance([FromBody] GrievanceCreateDTO grievanceDTO)
        {
            var grievance = await _repository.CreateGrievance(grievanceDTO);
            return CreatedAtAction(nameof(GetGrievance), new { id = grievance.Id }, grievance);
        }

        /// <summary>
        /// Updates a single Grievance
        /// </summary>
        /// <param name="patchDoc"></param>
        /// <param name="id"></param>
        /// <response code="204">Grievance was updated succesfully</response>
        /// <response code="400">Must post JSON patch document.</response>
        /// <response code="404">Grievance was not found.</response>
        /// <remarks>
        /// Sample request:
        ///
        ///     PATCH /Grievance/{id}
        ///     [
        ///          {
        ///             "op":"replace",
        ///             "path":"/RespondentBody",
        ///             "value": "value body"
        ///          },
        ///          {
        ///             "op":"replace",
        ///             "path":"/RespondantId",
        ///             "value": 2
        ///          }
        ///     ]
        /// </remarks>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Roles = Roles.Admin)]
        [HttpPatch("{id:int}")]
        public async Task<IActionResult> UpdateGrievance([FromBody] JsonPatchDocument<GrievanceUpdateDTO> patchDoc, int id)
        {
            if (patchDoc == null)
            {
                return BadRequest();
            }

            var grievance = await _repository.UpdateGrievance(id, patchDoc);
            
            if (grievance == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
