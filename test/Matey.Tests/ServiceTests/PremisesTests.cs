using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Threading.Tasks;
using Matey.Data;
using Matey.Domain.Models.Premises;
using Matey.Service.PremisesServices;
using Microsoft.EntityFrameworkCore;
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
        public void GetById()
        {
            using (var context = new MateyDbContext(ContextOptions))
            {
                var service = new PremisesService(context);

                Assert.Equal("Name1", service.GetById(1).Name);
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

        [Fact]
        public void GetMembers_ZeroMembers()
        {
            using (var context = new MateyDbContext(ContextOptions))
            {
                var service = new PremisesService(context);

                Assert.Equal(0, service.GetMembers(service.GetById(1)).Count());
            }
        }

        [Fact]
        public void GetMembers_OneMember()
        {
            using (var context = new MateyDbContext(ContextOptions))
            {
                var service = new PremisesService(context);

                var premises = service.GetById(1);

                premises.Members.Add(new PremisesMember());

                Assert.Equal(1, service.GetMembers(service.GetById(1)).Count());
            }
        }

        [Fact]
        public void AddMember()
        {
            using (var context = new MateyDbContext(ContextOptions))
            {
                var service = new PremisesService(context);

                var premises = service.GetById(1);

                service.AddMember(premises, new PremisesMember());

                Assert.Equal(1, context.Premises.FirstOrDefault(p => p.Id == 1).Members.Count);
            }

            // Create a new context to force a reload in order to confirm that SaveChanges has been called.
            using (var context = new MateyDbContext(ContextOptions))
            {
                Assert.Equal(1, context.Premises.Include(p => p.Members).FirstOrDefault(p => p.Id == 1).Members.Count);
            }
        }

        [Fact]
        public void RemoveMember()
        {
            using (var context = new MateyDbContext(ContextOptions))
            {
                var service = new PremisesService(context);

                var premises = service.GetById(1);

                var member = new PremisesMember();

                context.Premises.Include(p => p.Members).FirstOrDefault(p => p.Id == 1).Members.Add(member);

                context.SaveChanges();

                Assert.Equal(1, context.Premises.Include(p => p.Members).FirstOrDefault(p => p.Id == 1).Members.Count);

                service.RemoveMember(premises, member);

                Assert.Equal(0, context.Premises.Include(p => p.Members).FirstOrDefault(p => p.Id == 1).Members.Count);
            }

            // Create a new context to force a reload in order to confirm that SaveChanges has been called.
            using (var context = new MateyDbContext(ContextOptions))
            {
                Assert.Equal(0, context.Premises.Include(p => p.Members).FirstOrDefault(p => p.Id == 1).Members.Count);
            }
        }
    }
}
