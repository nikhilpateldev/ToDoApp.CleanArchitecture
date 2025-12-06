using Microsoft.EntityFrameworkCore;
using Shared.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Persistence
{
    public sealed class EfRepository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _context;

        public EfRepository(DbContext context)
        {
            _context = context;
        }

        public async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
            => await _context.Set<T>().FindAsync(new object[] { id }, cancellationToken);

        public async Task<IReadOnlyList<T>> GetAllAsync(CancellationToken cancellationToken = default)
            => await _context.Set<T>().AsNoTracking().ToListAsync(cancellationToken);

        public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
            => await _context.Set<T>().AddAsync(entity, cancellationToken);

        public void Update(T entity)
            => _context.Set<T>().Update(entity);

        public void Delete(T entity)
            => _context.Set<T>().Remove(entity);
    }
}
