using System.Collections.Generic;
using Matey.Domain.Models.Premises;
using Matey.Service.Common;

namespace Matey.Service.PremisesServices
{
    public interface IPremisesService : IEntityService<Premises>
    {
        IEnumerable<PremisesMember> GetMembers(Premises premises);

        Premises AddMember(Premises premises, PremisesMember member);
    }
}