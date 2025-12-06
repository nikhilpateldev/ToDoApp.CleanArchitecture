using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Infrastructure.Repositories
{
    public interface IRepository<T> :
    IReadRepository<T>,
    IWriteRepository<T>
    where T : class
    {
    }
}
