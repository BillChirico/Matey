using System.Collections.Generic;
using Matey.Domain.Models.Common;

namespace Matey.Domain.Models.Premises
{
    public class Premises : Entity<int>
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public List<PremisesMember> Members { get; set; }
    }
}