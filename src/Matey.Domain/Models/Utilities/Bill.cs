using System;
using System.Collections.Generic;
using Matey.Domain.Models.Common;
using Matey.Domain.Models.Premises;

namespace Matey.Domain.Models.Utilities
{
    public class Bill : Entity
    {
        public DateTimeOffset ReceivedDate { get; set; }

        public DateTimeOffset DueDate { get; set; }

        public decimal AmountDue { get; set; }

        public IEnumerable<PremisesMember> Transactions { get; set; }

        public int UtilityId { get; set; }

        public Utility Utility { get; set; }
    }
}