using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Matey.Data;
using Matey.Service.Common;
using Microsoft.EntityFrameworkCore;

namespace Matey.Service.Premises
{
    public class PremisesService : EntityService<Domain.Models.Premises.Premises>, IPremisesService
    {
        private readonly MateyDbContext _context;

        public PremisesService(MateyDbContext context) : base(context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));

            _context = context;
        }

        public override IEnumerable<Domain.Models.Premises.Premises> GetAll()
        {
            return _context.Premises.Include(p => p.Members).AsEnumerable();
        }
    }
}
