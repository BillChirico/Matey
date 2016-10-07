using Matey.Domain.Models.Identity;
using Matey.Domain.Models.Premises;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Matey.Data
{
    public class MateyDbContext : IdentityDbContext<User>
    {
        public MateyDbContext(DbContextOptions<MateyDbContext> options)
            : base(options)
        {
        }

        public DbSet<Premises> Premises { get; set; }

        public DbSet<PremisesMember> PremisesMembers { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}