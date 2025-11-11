using MyOrganizationApp.Application.DTOs;
using MyOrganizationApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyOrganizationApp.Application.Services.Interface
{
    public interface IDepartmentService
    {
        Task<IEnumerable<DepartmentDto>> GetAllDepartments();
        Task<DepartmentDto> GetDepartmentById(int id);
        Task CreateDepartment(DepartmentDto department);
        Task UpdateDepartment(DepartmentDto department);
        Task<bool> DeleteDepartment(int id);
        Task<bool> Any(Expression<Func<TblDepartment, bool>> filter);
    }
}
