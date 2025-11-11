using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using MyOrganizationApp.Application.Common.Interfaces;
using MyOrganizationApp.Domain.Entities;
using MyOrganizationApp.Infrastructure.Data;

namespace MyOrganizationApp.Infrastructure.Repository
{
    public class DepartmentRepository : Repository<TblDepartment>, IDepartmentRepository
    {
        private readonly MyOrgDbContext _db;

        public DepartmentRepository(MyOrgDbContext db) : base(db) 
        {
            _db = db;
        }
        
        public async Task Update(TblDepartment entity)
        {
           _db.TblDepartments.Update(entity);
        }
    }
}
