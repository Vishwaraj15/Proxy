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
        IEnumerable<TblDepartment> GetAllDepartments();
        TblDepartment GetDepartmentById(int id);
        void CreateDepartment(TblDepartment villa);
        void UpdateDepartment(TblDepartment villa);
        bool DeleteDepartment(int id);
        bool Any(Expression<Func<TblDepartment, bool>> filter);
    }
}
