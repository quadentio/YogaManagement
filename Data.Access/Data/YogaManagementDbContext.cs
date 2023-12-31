﻿using Data.Models;
using Microsoft.EntityFrameworkCore;
using Utilities.Helper;

namespace Data.Access.Data
{
    public class YogaManagementDbContext : DbContext
    {
        public YogaManagementDbContext(DbContextOptions<YogaManagementDbContext> options) : base(options)
        {

        }

        #region DBSet
        public DbSet<Client> Clients { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define table Class
            modelBuilder.Entity<Class>().HasKey(m => m.ClassId);
            modelBuilder.Entity<Class>(m =>
            {
                m.Property<string>("ClassName").HasMaxLength(50);
                m.Property<string>("ClassType").HasMaxLength(10);
                m.Property<string>("MonthPeriod").HasMaxLength(2);
            });

            // Seed Data
            var salt = EncryptionHelper.CreateSalt();
            modelBuilder.Entity<User>()
                .HasData(
                new User {
                    UserId = Guid.NewGuid(),
                    UserName = "admin",
                    Role = "admin",
                    Salt = salt,
                    Password = EncryptionHelper.HashPassword("Admin@123", salt),
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                }
            );
        }
    }
}
