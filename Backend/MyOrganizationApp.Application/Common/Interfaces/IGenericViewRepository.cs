using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyOrganizationApp.Application.Common.Interfaces
{
    // Define a generic, read-only interface for Keyless Entity Types (Views)
    // TView is constrained to be a class, representing a database view model/entity.
    public interface IGenericViewRepository<TView> where TView : class
    {
        // Gets all records from the view asynchronously
        Task<IReadOnlyList<TView>> GetAllAsync();

        // Finds records based on a predicate (e.g., summary.TotalRevenue > 1000)
        Task<IReadOnlyList<TView>> FindAsync(Expression<Func<TView, bool>> predicate);

        // Gets a single, specific record (e.g., summary for a specific ProductId)
        // Since views don't have primary keys, we search by a unique property combination.
        Task<TView?> GetSingleByConditionAsync(Expression<Func<TView, bool>> predicate);
    }
}
