using System.Collections.Generic;
using Matey.Domain.Models.Common;
using Matey.Domain.Models.Identity;
using Matey.Domain.Models.Utilities;
using Microsoft.AspNetCore.Authentication;

namespace Matey.Domain.Models.Premises
{
    public class PremisesMember : Entity
    {
        public string UserId { get; set; }

        public User User { get; set; }

        public bool Admin { get; set; }

        public IEnumerable<Utility> ManagedUtilities { get; set; }

        public IEnumerable<Transaction> Transactions { get; set; }
    }
}