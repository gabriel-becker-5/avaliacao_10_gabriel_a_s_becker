using _02_Application.DTOs;
using _02_Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace _01_Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class FuncionariosController : ControllerBase
    {
        private readonly IFuncionarioService _funcionarioService;

        public FuncionariosController(IFuncionarioService funcionarioService)
        {
            _funcionarioService = funcionarioService;
        }

        /// <summary>
        /// Creates a new employee in the database.
        /// </summary>
        /// <param name="dto">Fields: Employee Name, Position, Salary, Department.</param>
        /// <returns>The employee record has been created.</returns>
        /// <response code="201">Employee record created.</response>
        /// <response code="400">Please check the information provided.</response>
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [HttpPost]
        public async Task<IActionResult> CreateEmployee(FuncionarioInputDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var novoFuncionario = await _funcionarioService.CreateAsync(dto);

            return CreatedAtAction(nameof(GetEmployeeById),
                new { id = novoFuncionario.Id }, novoFuncionario);
        }

        /// <summary>
        /// Returns a list of all employee records.
        /// </summary>
        [ProducesResponseType(200)]
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            return Ok(await _funcionarioService.GetAllAsync());
        }

        /// <summary>
        /// Returns an employee's record based on the specified ID number.
        /// </summary>
        /// <param name="id">Employee ID number.</param>
        /// <returns>Employee record.</returns>
        /// <response code="200">Ok, Employee record.</response>
        /// <response code="404">Record not found.</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            try
            {
                return Ok(await _funcionarioService.GetByIdAsync(id));
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Updates an employee's record based on the specified ID number.
        /// </summary>
        /// <param name="id">Employee ID number.</param>
        /// <param name="dto">Fields: Employee Name, Position, Salary, Department.</param>
        /// <response code="204">Ok, Employee record updated.</response>
        /// <response code="404">Record not found.</response>
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, FuncionarioInputDto dto)
        {
            try
            {
                await _funcionarioService.UpdateAsync(id, dto);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Deletes an employee's record based on the specified ID number.
        /// </summary>
        /// <param name="id">Employee ID number.</param>
        /// <response code="204">Ok, Employee record deleted.</response>
        /// <response code="404">Record not found.</response>
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            try
            {
                await _funcionarioService.DeleteAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}