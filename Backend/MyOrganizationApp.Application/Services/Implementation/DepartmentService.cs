using MyOrganizationApp.Application.Common.Interfaces;
using MyOrganizationApp.Application.Services.Interface;
using MyOrganizationApp.Domain.Entities;

namespace MyOrganizationApp.Application.Services.Implementation
{
    public class DepartmentService : IDepartmentService
    {

        private readonly IUnitOfWork _unitOfWork;

        public DepartmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void CreateDepartment(TblDepartment tblDepartment)
        {
            _unitOfWork.DepartmentRepo.Add(tblDepartment);
            _unitOfWork.Save();
        }

       
        public bool DeleteDepartment(int id)
        {
            TblDepartment? objFromDb = _unitOfWork.DepartmentRepo.Get(u => u.PkdeptId == id);
            if (objFromDb is not null)
            {
                _unitOfWork.DepartmentRepo.Remove(objFromDb);
                _unitOfWork.Save();
            }
            return true;
        }

        public IEnumerable<TblDepartment> GetAllDepartments()
        {
            // return _unitOfWork.DepartmentRepo.GetAll(includeProperties: "TblEmployee");
            return _unitOfWork.DepartmentRepo.GetAll();
        }

        public TblDepartment GetDepartmentById(int id)
        {
            // return _unitOfWork.DepartmentRepo.Get(u => u.PkdeptId == id, includeProperties: "TblEmployee");
            return _unitOfWork.DepartmentRepo.Get(u => u.PkdeptId == id);
        }

        public void UpdateDepartment(TblDepartment tblDepartment)
        {
            _unitOfWork.DepartmentRepo.Update(tblDepartment);
            _unitOfWork.Save();
        }
    }
}
