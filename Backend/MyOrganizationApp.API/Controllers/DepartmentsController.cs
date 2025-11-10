using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyOrganizationApp.Infrastructure.Data;
using MyOrganizationApp.Domain.Entities;
using MyOrganizationApp.Application.Services.Interface;

namespace MyOrganizationApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentsController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        // GET: api/Departments
        [HttpGet]
        public ActionResult<IEnumerable<TblDepartment>> GetTblDepartments()
        {
            var departments = _departmentService.GetAllDepartments();
            return Ok(departments);
        }

        // GET: api/Departments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblDepartment>> GetTblDepartment(int id)
        {
            var tblDepartment = _departmentService.GetDepartmentById(id);

            if (tblDepartment == null)
            {
                return NotFound();
            }

            return tblDepartment;
        }

        // PUT: api/Departments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblDepartment(int id, TblDepartment tblDepartment)
        {
            if (id != tblDepartment.PkdeptId)
            {
                return BadRequest();
            }

            try
            {
                _departmentService.UpdateDepartment(tblDepartment);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (TblDepartmentExists(id) == null)
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
        public async Task<ActionResult<TblDepartment>> PostTblDepartment(TblDepartment tblDepartment)
        {
            _departmentService.CreateDepartment(tblDepartment);

            return CreatedAtAction("GetTblDepartment", new { id = tblDepartment.PkdeptId }, tblDepartment);
        }

        // DELETE: api/Departments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblDepartment(int id)
        {
            var tblDepartment = _departmentService.GetDepartmentById(id);
            if (tblDepartment == null)
            {
                return NotFound();
            }

            _departmentService.DeleteDepartment(tblDepartment.PkdeptId);
            return NoContent();
        }

        private TblDepartment TblDepartmentExists(int id)
        {
            return _departmentService.GetDepartmentById(id);
        }
    }
}
