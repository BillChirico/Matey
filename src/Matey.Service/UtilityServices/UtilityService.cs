using System;
using Matey.Domain;
using Matey.Domain.Models.Utilities;
using Matey.Service.Common;

namespace Matey.Service.UtilityServices
{
    public class UtilityService : EntityService<Utility>, IUtilityService
    {
        private readonly MateyDbContext _context;

        public UtilityService(MateyDbContext context) : base(context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));

            _context = context;
        }
    }
}