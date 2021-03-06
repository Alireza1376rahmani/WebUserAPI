using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructure.Data
{
    public class MyContext : DbContext
    {
        public DbSet<Principal> Principals { get; set; }
        public DbSet<Party> Parties { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.\SQLEXPRESS;Initial Catalog=FirstTest;Integrated Security=True;MultipleActiveResultSets=True;Application Name=TrainingApp");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Principal>()
            .OwnsMany(p => p.Memberships, a =>
            {
                a.WithOwner()
                .HasForeignKey("PrincipalId");
                a.HasOne<Group>()
                .WithMany()
                .HasForeignKey(z => z.GroupId)
                .OnDelete(DeleteBehavior.NoAction);
            });

            //modelBuilder.Entity<Principal>()
            //    .HasOne<Party>(p => p.Party)
            //    .WithOne();
            //.HasForeignKey<Party>();

            modelBuilder.Entity<User>()
                .OwnsOne(p => p.Party, a =>
                {
                    a.HasOne<Party>().
                    WithOne().
                    HasForeignKey<PartyRef>(x => x.PartyId);
                });

            // modelBuilder.Entity<Principal>().OwnsOne(typeof(Party), "Party");


            modelBuilder.Entity<Principal>()
                .HasDiscriminator()
                .HasValue<User>("User")
                .HasValue<Group>("Group");

            modelBuilder.Entity<Party>()
                .HasDiscriminator()
                .HasValue<BusinessParty>("Business")
                .HasValue<IndividualParty>("Individual");

        }
    }
}

