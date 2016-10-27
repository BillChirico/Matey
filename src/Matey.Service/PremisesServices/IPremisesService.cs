using System.Collections.Generic;
using Matey.Domain.Models.Premises;
using Matey.Service.Common;

namespace Matey.Service.PremisesServices
{
    public interface IPremisesService : IEntityService<Premises>
    {
        /// <summary>
        ///     Gets all of the members of the premises.
        /// </summary>
        /// <param name="premises">Premises to get the members of.</param>
        /// <returns>List of PremisesMember.</returns>
        IEnumerable<PremisesMember> GetMembers(Premises premises);

        /// <summary>
        ///     Adds a member to the premises.
        /// </summary>
        /// <param name="premises">Premises to add the new member to.</param>
        /// <param name="member">Member to be added to the premises.</param>
        /// <returns>Updated Premises.</returns>
        Premises AddMember(Premises premises, PremisesMember member);

        /// <summary>
        ///     Remove a member from the premises.
        /// </summary>
        /// <param name="premises">Premises to remove the member from.</param>
        /// <param name="member">Member to be removed from the premises.</param>
        /// <returns>Updated premises.</returns>
        Premises RemoveMember(Premises premises, PremisesMember member);

        bool ContainsMember(Premises premises, string userId);
    }
}