using Shared.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Domain.Base
{
    public abstract class AggregateRoot : Entity, IAggregateRoot
    {
    }
}
