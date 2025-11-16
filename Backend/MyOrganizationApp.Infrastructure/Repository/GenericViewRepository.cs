using Microsoft.EntityFrameworkCore;
using MyOrganizationApp.Application.Common.Interfaces;
using MyOrganizationApp.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyOrganizationApp.Infrastructure.Repository
{
    // Concrete implementation of the generic read-only repository
    public class GenericViewRepository<TView> : IGenericViewRepository<TView> where TView : class
    {
        private readonly MyOrgDbContext _dbContext;
        private readonly DbSet<TView> _dbSet;

        public GenericViewRepository(MyOrgDbContext dbContext)
        {
            _dbContext = dbContext;
            // Use DbContext.Set<TView>() to get the DbSet for the Keyless Entity Type
            _dbSet = _dbContext.Set<TView>();
        }

        public async Task<IReadOnlyList<TView>> GetAllAsync()
        {
            // Views should always be queried with AsNoTracking() as they are read-only
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public async Task<IReadOnlyList<TView>> FindAsync(Expression<Func<TView, bool>> predicate)
        {
            return await _dbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public async Task<TView?> GetSingleByConditionAsync(Expression<Func<TView, bool>> predicate)
        {
            // Use FirstOrDefaultAsync for fetching a single result
            return await _dbSet.AsNoTracking().FirstOrDefaultAsync(predicate);
        }
    }
}
