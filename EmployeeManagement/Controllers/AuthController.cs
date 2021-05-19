using AutoMapper;
using EmployeeManagement.Models;
using EmployeeManagement.Models.Auth;
using EmployeeManagement.Models.Constants;
using EmployeeManagement.Models.DTOs.EmployeeDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly UserManager<Employee> _userManager;
        private readonly SignInManager<Employee> _signInManager;

        public AuthController(IMapper mapper, UserManager<Employee> userManager, SignInManager<Employee> signInManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        /// <summary>
        /// If registration is completed successfully, an employee user will be created and will return a login token.
        /// </summary>
        /// <param name="userModel"></param>
        /// <response code="200"></response>
        /// <response code="400"></response>
        [HttpPost("Register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register(UserRegistration userModel)
        {
            if (userModel == null)
            {
                return BadRequest();
            }

            var user = _mapper.Map<Employee>(userModel);

            var result = await _userManager.CreateAsync(user, userModel.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }

                return BadRequest(ModelState);
            }

            await _userManager.AddToRoleAsync(user, "User");

            await _signInManager.SignInAsync(user, isPersistent: false);

            return Ok();
        }

        /// <summary>
        /// If an admin registered successfully, an employee user will be created and will return a login token.
        /// </summary>
        /// <param name="userModel"></param>
        /// <response code="200"></response>
        /// <response code="400"></response>
        [HttpPost("Register-Admin")]
        [Authorize(Roles = Roles.Admin)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RegisterAdmin(UserRegistration userModel)
        {
            if (userModel == null)
            {
                return BadRequest();
            }

            var user = _mapper.Map<Employee>(userModel);

            var result = await _userManager.CreateAsync(user, userModel.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }

                return BadRequest(ModelState);
            }

            await _userManager.AddToRoleAsync(user, "Admin");

            await _signInManager.SignInAsync(user, isPersistent: false);

            return Ok();
        }

        /// <summary>
        /// If login is succesfull, token will be returned.
        /// If login failed, an array of model state errors will be returned.
        /// </summary>
        /// <param name="userModel"></param>
        /// <response code="200"></response>
        /// <response code="400"></response>
        [HttpPost("Login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Login(UserLogin userModel)
        {
            if (userModel == null)
            {
                return BadRequest();
            }

            var result = await _signInManager.PasswordSignInAsync(userModel.UserName, userModel.Password, userModel.RememberMe, false);
            if (result.Succeeded)
            {
                return Ok();
            }

            else
            {
                ModelState.AddModelError("", "Invalid UserName or Password");
                return BadRequest(ModelState);
            }
        }
        
        /// <summary>
         /// If login is succesfull, token will be returned.
         /// If login failed, an array of model state errors will be returned.
         /// </summary>
         /// <response code="200"></response>
        [HttpPost("Logout")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();            
            return Ok();
        }
    }
}
