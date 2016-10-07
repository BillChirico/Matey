using Matey.Domain.Models.Common;
using Matey.Domain.Models.Identity;

namespace Matey.Domain.Models.Premises
{
    public class PremisesMember : Entity
    {
        public string UserId { get; set; }

        public User User { get; set; }

        public bool Admin { get; set; }
    }
}