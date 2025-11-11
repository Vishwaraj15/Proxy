using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyOrganizationApp.Application.Services.Interface;
using MyOrganizationApp.Application.DTOs;

namespace MyOrganizationApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;
        private readonly DepartmentMapper _departmentMapper;
        public DepartmentsController(IDepartmentService departmentService, DepartmentMapper departmentMapper)
        {
            _departmentService = departmentService;
            _departmentMapper = departmentMapper;
        }

        // GET: api/Departments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DepartmentDto>>> GetDepartments()
        {
            var departments = await _departmentService.GetAllDepartments();
            return Ok(departments);
        }

        // GET: api/Departments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DepartmentDto>> GetDepartment(int id)
        {
            var departmentDto = await _departmentService.GetDepartmentById(id);

            if (departmentDto == null)
            {
                return NotFound();
            }

            return departmentDto;
        }

        // PUT: api/Departments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepartment(int id, DepartmentDto departmentDto)
        {
            if (id != departmentDto.ID)
            {
                return BadRequest();
            }

            try
            {
                await _departmentService.UpdateDepartment(departmentDto);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await DepartmentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Departments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DepartmentDto>> PostDepartment(DepartmentDto department)
        {
            await _departmentService.CreateDepartment(department);

            return CreatedAtAction("GetTblDepartment", new { id = department.ID }, department);
        }

        // DELETE: api/Departments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var department = await _departmentService.GetDepartmentById(id);
            if (department == null)
            {
                return NotFound();
            }

            await _departmentService.DeleteDepartment(department.ID);
            return NoContent();
        }

        private async Task<bool> DepartmentExists(int id)
        {
            return await _departmentService.Any(d => d.PkdeptId == id);
        }
    }
}
