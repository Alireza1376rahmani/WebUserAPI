using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructure.Data
{
    public class MyContext : DbContext
    {
        public DbSet<Principal> Principals { get; set; }
        public DbSet<Membership> Memberships { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.\SQLEXPRESS;Initial Catalog=FirstTest;Integrated Security=True;MultipleActiveResultSets=True;Application Name=TrainingApp");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Principal>()
                .Ignore(x => x.Groups)
                .HasDiscriminator<string>("principal_type")
                .HasValue<User>("user")
                .HasValue<Group>("group");

            modelBuilder.Entity<Membership>().HasKey(m => new { m.PrincipalId, m.GroupId });

            modelBuilder.Entity<Membership>()
                .HasOne<Principal>(m => m.Principal)
                .WithMany("memberships")
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Membership>()
                .HasOne<Group>(m => m.Group)
                .WithMany();
        }
    }
}

