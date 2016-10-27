using System;
using System.Collections.Generic;
using System.Linq;
using Matey.Data;
using Matey.Domain.Models.Premises;
using Matey.Service.Common;
using Microsoft.EntityFrameworkCore;

namespace Matey.Service.PremisesServices
{
    public class PremisesService : EntityService<Premises>, IPremisesService
    {
        private readonly MateyDbContext _context;

        public PremisesService(MateyDbContext context) : base(context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));

            _context = context;
        }

        public override IEnumerable<Premises> GetAll()
        {
            return _context.Premises.Include(p => p.Members).AsEnumerable();
        }

        /// <summary>
        ///     Gets all of the members of the premises.
        /// </summary>
        /// <param name="premises">Premises to get the members of.</param>
        /// <returns>List of PremisesMember.</returns>
        public IEnumerable<PremisesMember> GetMembers(Premises premises)
        {
            return _context.Premises.Include(p => p.Members).ThenInclude(m => m.User).FirstOrDefault(p => p == premises).Members;
        }

        /// <summary>
        ///     Adds a member to the premises.
        /// </summary>
        /// <param name="premises">Premises to add the new member to.</param>
        /// <param name="member">Member to be added to the premises.</param>
        /// <returns>Updated Premises.</returns>
        public Premises AddMember(Premises premises, PremisesMember member)
        {
            premises.Members.Add(member);

            _context.SaveChanges();

            return premises;
        }

        public override Premises GetById(int id)
        {
            return _context.Premises.Include(p => p.Members).FirstOrDefault(p => p.Id == id);
        }

        /// <summary>
        ///     Remove a member from the premises.
        /// </summary>
        /// <param name="premises">Premises to remove the member from.</param>
        /// <param name="member">Member to be removed from the premises.</param>
        /// <returns>Updated premises.</returns>
        public Premises RemoveMember(Premises premises, PremisesMember member)
        {
            premises.Members.Remove(member);

            _context.SaveChanges();

            return premises;
        }

        public bool ContainsMember(Premises premises, string userId)
        {
            return GetMembers(premises).Any(m => m.UserId == userId);
        }
    }
}