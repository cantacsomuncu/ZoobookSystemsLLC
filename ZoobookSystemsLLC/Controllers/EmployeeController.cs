using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.Json;
using ZoobookSystemsLLC.Entities.Concrete;
using ZoobookSystemsLLC.Entities.Dtos;
using ZoobookSystemsLLC.Services.Abstract;
using ZoobookSystemsLLC.Shared.Utilities.Results.ComplexTypes;

namespace ZoobookSystemsLLC.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeManager;
        private readonly IMapper _mapper;

        public EmployeeController(IMapper mapper, IEmployeeService employeeManager)
        {
            _mapper = mapper;
            _employeeManager = employeeManager;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var employees = await _employeeManager.GetAllAsync();
            return Ok(employees);
        }
        [Authorize(Roles = "Admin, User")]
        [HttpGet]
        public async Task<ActionResult> GetById(int id)
        {
            var employee = await _employeeManager.GetAsync(id);
            return Ok(employee);
        }
        [Authorize(Roles = "Admin, User")]
        [HttpPut]
        public async Task<ActionResult> Update(EmployeeUpdateDto employeeUpdateDto)
        {
            var employee = await _employeeManager.UpdateAsync(employeeUpdateDto);
            return Ok(employee);
        }
        [Authorize(Roles = "Admin, User")]
        [HttpPost]
        public async Task<IActionResult> Add(EmployeeAddDto employeeAddDto)
        {
            var result = await _employeeManager.AddAsync(employeeAddDto);
            {
                return Ok(result);
            }
        }

        [Authorize(Roles = "Admin, User")]
        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var employee = await _employeeManager.DeleteAsync(id);
            return Ok(employee);
        }
    }
}
