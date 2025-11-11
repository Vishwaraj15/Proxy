using MyOrganizationApp.Application.Common.Interfaces;
using MyOrganizationApp.Application.DTOs;
using MyOrganizationApp.Application.Services.Interface;
using MyOrganizationApp.Domain.Entities;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MyOrganizationApp.Application.Services.Implementation
{
    public class DepartmentService : IDepartmentService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly DepartmentMapper _departmentMapper;
        
        public DepartmentService(IUnitOfWork unitOfWork, DepartmentMapper departmentMapper)
        {
            _unitOfWork = unitOfWork;
            _departmentMapper = departmentMapper;
        }

        public async Task CreateDepartment(DepartmentDto department)
        {
            TblDepartment tblDepartment = _departmentMapper.ToTblDepartment(department);
            await _unitOfWork.DepartmentRepo.Add(tblDepartment);
            await _unitOfWork.Save();
        }

       
        public async Task<bool> DeleteDepartment(int id)
        {
            TblDepartment? objFromDb = await _unitOfWork.DepartmentRepo.Get(u => u.PkdeptId == id);
            if (objFromDb is not null)
            {
                await _unitOfWork.DepartmentRepo.Remove(objFromDb);
                await _unitOfWork.Save();
            }
            return true;
        }

        public async Task<IEnumerable<DepartmentDto>> GetAllDepartments()
        {
            // return _unitOfWork.DepartmentRepo.GetAll(includeProperties: "TblEmployee");
            var departments = await _unitOfWork.DepartmentRepo.GetAll();
            var departmentsDto = _departmentMapper.ToDepartmentsDto(departments);
            return departmentsDto;
        }

        public async Task<DepartmentDto> GetDepartmentById(int id)
        {
            // return _unitOfWork.DepartmentRepo.Get(u => u.PkdeptId == id, includeProperties: "TblEmployee");
            var department = _departmentMapper.ToDepartmentDto(await _unitOfWork.DepartmentRepo.Get(u => u.PkdeptId == id));
            return department;
        }

        public async Task UpdateDepartment(DepartmentDto departmentDto)
        {
            await _unitOfWork.DepartmentRepo.Update(_departmentMapper.ToTblDepartment(departmentDto));
            await _unitOfWork.Save();
        }

        public async Task<bool> Any(Expression<Func<TblDepartment, bool>> filter)
        {
            return await _unitOfWork.DepartmentRepo.Any(filter);
        }
    }
}
