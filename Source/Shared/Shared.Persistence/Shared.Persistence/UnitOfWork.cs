using Microsoft.EntityFrameworkCore;
using Shared.Infrastructure.Repositories;
using Shared.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Persistence
{
    public sealed class UnitOfWork<TContext> : IUnitOfWork
    where TContext : DbContext
    {
        private readonly TContext _context;
        private readonly Dictionary<Type, object> _repositories = [];

        public UnitOfWork(TContext context)
        {
            _context = context;
        }

        public IRepository<T> Repository<T>() where T : class
        {
            var entityType = typeof(T);

            if (!_repositories.ContainsKey(entityType))
            {
                var repo = new EfRepository<T>(_context);
                _repositories[entityType] = repo;
            }

            return (IRepository<T>)_repositories[entityType];
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
            => _context.SaveChangesAsync(cancellationToken);

        public void Dispose() => _context.Dispose();
    }
}
