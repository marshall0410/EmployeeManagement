using AutoMapper;
using EmployeeManagement.Data;
using EmployeeManagement.Models;
using EmployeeManagement.Models.Constants;
using EmployeeManagement.Models.DTOs.SalaryDTOs;
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
    public class SalaryController : ControllerBase
    {
        private readonly ISalaryRepository _repository;
        public SalaryController(ISalaryRepository repository)
        {
            _repository = repository;
        }


        /// <summary>
        /// Retrieves an array of Salary 
        /// </summary>
        /// <returns>A list of Salary</returns>
        /// <response code="200"></response>
        /// <response code="404"></response>
        [HttpGet]
        [Authorize(Roles = Roles.Admin)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<SalaryDTO>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetSalary()
        {
            var DTOList = await _repository.GetSalary();
            if (DTOList == null)
            {
                return NotFound();
            }
            return Ok(DTOList);
        }

        /// <summary>
        /// Retrieves an array of Salary 
        /// </summary>
        /// <returns>A list of Salary</returns>
        /// <param name="id"></param>
        /// <response code="200"></response>
        /// <response code="404"></response>
        [HttpGet("{id:int}", Name = "GetSalary")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SalaryDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetSalary(int id)
        {
            var salary = await _repository.GetSalary(id);

            if (salary == null)
            {
                return NotFound();
            }

            return Ok(salary);
        }

        /// <summary>
        /// Creates a single Salary
        /// </summary>
        /// <param name="salaryDTO"></param>
        /// <returns>Creates a single Salary</returns>
        /// <response code="201">Salary was created succesfully</response>
        [HttpPost]
        [Authorize(Roles = Roles.Admin)]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(SalaryDTO))]
        public async Task<ActionResult> CreateSalary([FromBody] SalaryCreateDTO salaryDTO)
        {
            var salaryObj = await _repository.CreateSalary(salaryDTO);
            return CreatedAtAction(nameof(GetSalary), new { id = salaryObj.Id }, salaryObj);
        }

        /// <summary>
        /// Updates a single Salary
        /// </summary>
        /// <param name="patchDoc"></param>
        /// <param name="id"></param>
        /// <response code="204">Salary was updated succesfully</response>
        /// <response code="400">Must post JSON patch document.</response>
        /// <response code="404">Salary was not found.</response>
        /// <remarks>
        /// Sample request:
        ///
        ///     PATCH /Salary/{id}
        ///     [
        ///          {
        ///             "op":"replace",
        ///             "path":"/AnnualSalary",
        ///             "value": 50000.55
        ///          },
        ///          {
        ///             "op":"replace",
        ///             "path":"/EmployeeId",
        ///             "value": "2"
        ///          },
        ///          {
        ///             "op":"replace",
        ///             "path":"/Allowance",
        ///             "value": 2000.34
        ///          },
        ///          {
        ///             "op":"replace",
        ///             "path":"/Tax",
        ///             "value": 6.53
        ///          },
        ///          {
        ///             "op":"replace",
        ///             "path":"/GrossSalary",
        ///             "value": 57522.78
        ///          },
        ///          {
        ///             "op":"replace",
        ///             "path":"/NetSalary",
        ///             "value": 62555.43
        ///          }
        ///     ]
        /// </remarks>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Roles = Roles.Admin)]
        [HttpPatch("{id:int}")]
        public async Task<IActionResult> UpdateSalary([FromBody] JsonPatchDocument<Salary> patchDoc, int id)
        {
            if (patchDoc == null)
            {
                return BadRequest();
            }

            var salary = await _repository.UpdateSalary(id, patchDoc);

            if (salary == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
