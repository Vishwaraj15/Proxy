

using MyOrganizationApp.Domain.Entities;

namespace MyOrganizationApp.Application.Common.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        IDepartmentRepository DepartmentRepo { get; }
        IGenericViewRepository<VwEmployeeDepartmentDetail> VwEmployeeDepartmentDetailRepo { get; }
        Task Save();
    }
}
