using Matey.Domain.Models.Common;
using Matey.Domain.Models.Premises;

namespace Matey.Domain.Models.Utilities
{
    public class Transaction : Entity
    {
        public bool Paid { get; set; }

        public int MemberId { get; set; }

        public PremisesMember Member { get; set; }

        public int BillId { get; set; }

        public Bill Bill { get; set; }
    }
}