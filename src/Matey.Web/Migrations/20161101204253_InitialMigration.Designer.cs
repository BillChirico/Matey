using System;
using Matey.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Matey.Web.Migrations
{
    [DbContext(typeof(MateyDbContext))]
    [Migration("20161101204253_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Matey.Domain.Models.Identity.User", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Matey.Domain.Models.Premises.Premises", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Premises");
                });

            modelBuilder.Entity("Matey.Domain.Models.Premises.PremisesMember", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Admin")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(false);

                    b.Property<int?>("BillId");

                    b.Property<int?>("PremisesId");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("BillId");

                    b.HasIndex("PremisesId");

                    b.HasIndex("UserId");

                    b.ToTable("PremisesMembers");
                });

            modelBuilder.Entity("Matey.Domain.Models.Utilities.Bill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("AmountDue");

                    b.Property<DateTimeOffset>("DueDate");

                    b.Property<DateTimeOffset>("ReceivedDate");

                    b.Property<int>("UtilityId");

                    b.HasKey("Id");

                    b.HasIndex("UtilityId");

                    b.ToTable("Bills");
                });

            modelBuilder.Entity("Matey.Domain.Models.Utilities.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BillId");

                    b.Property<int>("MemberId");

                    b.Property<bool>("Paid")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(false);

                    b.Property<int?>("PremisesMemberId");

                    b.HasKey("Id");

                    b.HasIndex("BillId");

                    b.HasIndex("MemberId");

                    b.HasIndex("PremisesMemberId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("Matey.Domain.Models.Utilities.Utility", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ManagerId");

                    b.Property<string>("Name");

                    b.Property<int?>("PremisesMemberId");

                    b.HasKey("Id");

                    b.HasIndex("ManagerId");

                    b.HasIndex("PremisesMemberId");

                    b.ToTable("Utilities");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Matey.Domain.Models.Premises.PremisesMember", b =>
                {
                    b.HasOne("Matey.Domain.Models.Utilities.Bill")
                        .WithMany("Transactions")
                        .HasForeignKey("BillId");

                    b.HasOne("Matey.Domain.Models.Premises.Premises")
                        .WithMany("Members")
                        .HasForeignKey("PremisesId");

                    b.HasOne("Matey.Domain.Models.Identity.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Matey.Domain.Models.Utilities.Bill", b =>
                {
                    b.HasOne("Matey.Domain.Models.Utilities.Utility", "Utility")
                        .WithMany("Bills")
                        .HasForeignKey("UtilityId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Matey.Domain.Models.Utilities.Transaction", b =>
                {
                    b.HasOne("Matey.Domain.Models.Utilities.Bill", "Bill")
                        .WithMany()
                        .HasForeignKey("BillId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Matey.Domain.Models.Premises.PremisesMember", "Member")
                        .WithMany()
                        .HasForeignKey("MemberId");

                    b.HasOne("Matey.Domain.Models.Premises.PremisesMember")
                        .WithMany("Transactions")
                        .HasForeignKey("PremisesMemberId");
                });

            modelBuilder.Entity("Matey.Domain.Models.Utilities.Utility", b =>
                {
                    b.HasOne("Matey.Domain.Models.Premises.PremisesMember", "Manager")
                        .WithMany()
                        .HasForeignKey("ManagerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Matey.Domain.Models.Premises.PremisesMember")
                        .WithMany("ManagedUtilities")
                        .HasForeignKey("PremisesMemberId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Matey.Domain.Models.Identity.User")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Matey.Domain.Models.Identity.User")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Matey.Domain.Models.Identity.User")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
