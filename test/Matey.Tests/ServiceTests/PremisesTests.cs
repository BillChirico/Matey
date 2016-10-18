using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Matey.Data;
using Matey.Domain.Models.Premises;
using Matey.Service.Premises;
using Xunit;

namespace Matey.Tests.ServiceTests
{
    public class PremisesTests : ServiceTest
    {
        public PremisesTests()
        {
            using (var context = new MateyDbContext(ContextOptions))
            {
                // Add 5 premises
                for (var i = 1; i <= 5; i++)
                {
                    context.Premises.Add(new Premises
                    {
                        Id = i,
                        Name = "Name" + i,
                        Address = "Address" + i
                    });
                }

                context.SaveChanges();
            }
        }

        [Fact]
        public void GetById_ZeroMembers()
        {
            using (var context = new MateyDbContext(ContextOptions))
            {
                var service = new PremisesService(context);

                Assert.Equal(0, service.GetById(1).Members.Count);
            }
        }

        [Fact]
        public void GetAll_ZeroMembers()
        {
            using (var context = new MateyDbContext(ContextOptions))
            {
                var service = new PremisesService(context);

                Assert.Equal(0, service.GetAll().FirstOrDefault().Members.Count);
            }
        }
    }
}
