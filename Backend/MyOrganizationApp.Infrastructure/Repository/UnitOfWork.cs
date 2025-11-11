using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyOrganizationApp.Application.Common.Interfaces;
using MyOrganizationApp.Infrastructure.Data;

namespace MyOrganizationApp.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyOrgDbContext _db;
        public IDepartmentRepository DepartmentRepo {get; private set;}
 
        public UnitOfWork(MyOrgDbContext db)
        {
            _db = db;
            DepartmentRepo = new DepartmentRepository(_db);
            //EmployeeRepo = new EmployeeRepository(_db);
        }

        public async Task Save()
        {
            await _db.SaveChangesAsync();
        }
    }
}
