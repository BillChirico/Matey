using Matey.Domain.Models.Identity;
using Matey.Domain.Models.Premises;
using Matey.Domain.Models.Utilities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Matey.Domain
{
    public class MateyDbContext : IdentityDbContext<User>
    {
        public MateyDbContext(DbContextOptions<MateyDbContext> options)
            : base(options)
        {
        }

        public DbSet<Premises> Premises { get; set; }

        public DbSet<PremisesMember> PremisesMembers { get; set; }

        public DbSet<Utility> Utilities { get; set; }

        public DbSet<Bill> Bills { get; set; }

        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Add default value of false to PremisesMember Admin property.
            builder.Entity<PremisesMember>()
                .Property(m => m.Admin)
                .HasDefaultValue(false);

            // Add default value of false to Transaction Paid property.
            builder.Entity<Transaction>()
                .Property(t => t.Paid)
                .HasDefaultValue(false);

            builder.Entity<PremisesMember>()
                .HasMany(m => m.Transactions)
                .WithOne().OnDelete(DeleteBehavior.Restrict);

            builder.Entity<PremisesMember>()
                .HasMany(m => m.ManagedUtilities)
                .WithOne().OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Transaction>()
                .HasOne(t => t.Member)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}