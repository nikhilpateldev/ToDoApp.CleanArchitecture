using Shared.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Domain.Events
{
    public sealed record TodoItemCompletedDomainEvent(Guid TodoItemId) : DomainEvent;
}
