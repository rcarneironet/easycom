using System;
using Easycom.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Easycom.Data.EF.Data
{
    public class AppContext : DbContext
    {
        public AppContext(DbContextOptions<AppContext> options) : base(options)
        {
        }

        public DbSet<Student> Student { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Student>(ConfigureStudent);
        }

        private void ConfigureStudent(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Student");

            builder.HasKey(x => x.ID);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.LastName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Phone)
                .IsRequired()
                .HasMaxLength(15);

            builder.Property(x => x.Address)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.City)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.State)
                .IsRequired()
                .HasMaxLength(2);

            builder.Property(x => x.Country)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
