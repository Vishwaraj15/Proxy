using MyOrganizationApp.Application.Common.Interfaces;
using MyOrganizationApp.Application.DTOs;
using MyOrganizationApp.Application.Services.Interface;
using MyOrganizationApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyOrganizationApp.Application.Services.Implementation
{
    public class LookupService : ILookupService
    {

        private readonly IUnitOfWork _unitOfWork;

        public LookupService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #region VwEmployeeDepartmentDetail
        // VwEmployeeDepartmentDetail related methods
        public async Task<IReadOnlyList<VwEmployeeDepartmentDetail>> GetAllEmployeeDepartmentDetailsAsync()
        {
            return await _unitOfWork.VwEmployeeDepartmentDetailRepo.GetAllAsync();
        }

        public async Task<IReadOnlyList<VwEmployeeDepartmentDetail>> FindAsyncEmployeeDepartmentDetailsAsync(Expression<Func<VwEmployeeDepartmentDetail, bool>> predicate)
        {
            return await _unitOfWork.VwEmployeeDepartmentDetailRepo.FindAsync(predicate);
        }

        public async Task<VwEmployeeDepartmentDetail?> GetSingleByConditionEmployeeDepartmentDetailsAsync(Expression<Func<VwEmployeeDepartmentDetail, bool>> predicate)
        {
            return await _unitOfWork.VwEmployeeDepartmentDetailRepo.GetSingleByConditionAsync(predicate);
        }
        #endregion
    }
}
