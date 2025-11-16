using Microsoft.EntityFrameworkCore;
using MyOrganizationApp.Application.Common.Interfaces;
using MyOrganizationApp.Domain.Entities;
using MyOrganizationApp.Infrastructure.Data;

namespace MyOrganizationApp.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyOrgDbContext _db;
        public IDepartmentRepository DepartmentRepo {get; private set;}

        // Inject the specific repository instance for the view entity
        public IGenericViewRepository<VwEmployeeDepartmentDetail> VwEmployeeDepartmentDetailRepo { get; private set; }

        public UnitOfWork(MyOrgDbContext db)
        {
            _db = db;
            DepartmentRepo = new DepartmentRepository(_db);
            //EmployeeRepo = new EmployeeRepository(_db);
            VwEmployeeDepartmentDetailRepo = new GenericViewRepository<VwEmployeeDepartmentDetail>(_db);
        }

        public async Task Save()
        {
            await _db.SaveChangesAsync();
        }

        // IDisposable implementation for resource cleanup
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
        }
    }
}
