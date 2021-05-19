using AutoMapper;
using EmployeeManagement.Data;
using EmployeeManagement.Models;
using EmployeeManagement.Models.Constants;
using EmployeeManagement.Models.DTOs.PayrollDTOs;
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
    public class PayrollController : ControllerBase
    {
        private readonly IPayrollRepository _repository;
         public PayrollController(IPayrollRepository repository)
         {
            _repository = repository;
         }


        /// <summary>
        /// Retrieves an array of Payroll 
        /// </summary>
        /// <returns>A list of Payroll</returns>
        /// <response code="200"></response>
        /// <response code="404"></response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<PayrollDTO>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetPayroll()
        {
            var DTOList = await _repository.GetPayroll();
            if(DTOList == null)
            {
                return NotFound();
            }
            return Ok(DTOList);
        }

        /// <summary>
        /// Retrieves an array of Payroll 
        /// </summary>
        /// <returns>A list of Payroll</returns>
        /// <param name="id"></param>
        /// <response code="200"></response>
        /// <response code="404"></response>
        [HttpGet("{id:int}", Name = "GetPayroll")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PayrollDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetPayroll(int id)
        {
            var payroll = await _repository.GetPayroll(id);

            if (payroll == null)
            {
                return NotFound();
            }

            return Ok(payroll);
        }

        /// <summary>
        /// Creates a single Payroll
        /// </summary>
        /// <param name="payrollDTO"></param>
        /// <returns>Creates a single Payroll</returns>
        /// <response code="201">Payroll was created succesfully</response>
        [HttpPost]
        [Authorize(Roles = Roles.Admin)]
        [ProducesResponseType(StatusCodes.Status201Created, Type=typeof(PayrollDTO))]
        public async Task<ActionResult> CreatePayroll([FromBody] PayrollCreateDTO payrollDTO)
        {
            var payrollObj = await _repository.CreatePayroll(payrollDTO);
            return CreatedAtAction(nameof(GetPayroll), new { id = payrollObj.Id }, payrollObj);
        }

        /// <summary>
        /// Updates a single Payroll
        /// </summary>
        /// <param name="patchDoc"></param>
        /// <param name="id"></param>
        /// <response code="204">Payroll was updated succesfully</response>
        /// <response code="400">Must post JSON patch document.</response>
        /// <response code="404">Payroll was not found.</response>
        /// <remarks>
        /// Sample request:
        ///
        ///     PATCH /Payroll/{id}
        ///     [
        ///          {
        ///             "op":"replace",
        ///             "path":"/Month",
        ///             "value": 2
        ///          },
        ///          {
        ///             "op":"replace",
        ///             "path":"/Year",
        ///             "value": 2021
        ///          },
        ///          {
        ///             "op":"replace",
        ///             "path":"/PaidSalary",
        ///             "value": 800.67
        ///          },
        ///          {
        ///             "op":"replace",
        ///             "path":"/EmployeeId",
        ///             "value": "1"
        ///          }
        ///     ]
        /// </remarks>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Roles = Roles.Admin)]
        [HttpPatch("{id:int}")]
        public async Task<IActionResult> UpdatePayroll([FromBody] JsonPatchDocument<Payroll> patchDoc, int id)
        {
            if (patchDoc == null)
            {
                return BadRequest();
            }

            var payroll = await  _repository.UpdatePayroll(id, patchDoc);

            if (payroll == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
