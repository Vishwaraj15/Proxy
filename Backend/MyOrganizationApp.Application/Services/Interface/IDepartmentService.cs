using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyOrganizationApp.Domain.Entities;

namespace MyOrganizationApp.Application.Services.Interface
{
    public interface IDepartmentService
    {
        IEnumerable<TblDepartment> GetAllDepartments();
        TblDepartment GetDepartmentById(int id);
        void CreateDepartment(TblDepartment villa);
        void UpdateDepartment(TblDepartment villa);
        bool DeleteDepartment(int id);
    }
}
