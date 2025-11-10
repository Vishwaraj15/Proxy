

namespace MyOrganizationApp.Application.Common.Interfaces
{
    public interface IUnitOfWork
    {
        IDepartmentRepository DepartmentRepo { get; }
        void Save();
    }
}
