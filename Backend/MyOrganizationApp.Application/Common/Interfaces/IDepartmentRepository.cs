using MyOrganizationApp.Domain.Entities;

namespace MyOrganizationApp.Application.Common.Interfaces
{
    public interface IDepartmentRepository : IRepository<TblDepartment>
    {
        Task Update(TblDepartment entity);

    }
}
