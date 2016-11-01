using System.Collections.Generic;
using Matey.Domain.Models.Common;
using Matey.Domain.Models.Premises;

namespace Matey.Domain.Models.Utilities
{
    public class Utility : Entity
    {
        public string Name { get; set; }

        public int PremisesId { get; set; }

        public Premises.Premises Premises { get; set; }

        public int ManagerId { get; set; }

        public PremisesMember Manager { get; set; }

        public IEnumerable<Bill> Bills { get; set; }
    }
}