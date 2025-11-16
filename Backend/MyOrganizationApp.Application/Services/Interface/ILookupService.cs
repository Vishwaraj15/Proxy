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
    public interface ILookupService
    {
        // Methods to get all lookup data

        // This is for getting all employee department details
        Task<IReadOnlyList<VwEmployeeDepartmentDetail>> GetAllEmployeeDepartmentDetailsAsync();
        Task<IReadOnlyList<VwEmployeeDepartmentDetail>> FindAsyncEmployeeDepartmentDetailsAsync(Expression<Func<VwEmployeeDepartmentDetail, bool>> predicate);
        Task<VwEmployeeDepartmentDetail?> GetSingleByConditionEmployeeDepartmentDetailsAsync(Expression<Func<VwEmployeeDepartmentDetail, bool>> predicate);
    }
}
