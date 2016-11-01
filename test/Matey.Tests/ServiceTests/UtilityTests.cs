using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Matey.Domain;
using Matey.Domain.Models.Premises;
using Matey.Domain.Models.Utilities;

namespace Matey.Tests.ServiceTests
{
    public class UtilityTests : ServiceTest
    {
        public UtilityTests()
        {
            using (var context = new MateyDbContext(ContextOptions))
            {
                // Add 5 premises
                for (var i = 1; i <= 5; i++)
                {
                    context.Utilities.Add(new Utility
                    {
                        Id = i,
                        Name = "Utility" + i
                    });

                    context.SaveChanges();
                }
            }
        }
    }
}