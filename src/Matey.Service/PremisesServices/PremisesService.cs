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

        public IEnumerable<PremisesMember> GetMembers(Premises premises)
        {
            return _context.Premises.FirstOrDefault(p => p == premises).Members;
        }

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
    }
}