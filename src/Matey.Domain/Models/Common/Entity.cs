using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Matey.Domain.Models.Common
{
    public abstract class Entity<T>
    {
        public T Id { get; set; }
    }
}
