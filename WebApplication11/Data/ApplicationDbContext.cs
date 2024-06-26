﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication11.Data.Identity;

namespace WebApplication11.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationIdentityUser, IdentityRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Можно создавать свойства для табличных полей
            builder.Entity<Student>().Property(z => z.Id).UseIdentityColumn();
            builder.Entity<Student>().Property(z => z.Name).HasMaxLength(100);

            builder.Entity<Student>().HasData(
                new Student
                {
                    Id = 1,
                    Name = "First",
                    BirthDate = DateTime.Now.AddYears(-20),
                    Price = 999.99m,
                });

            base.OnModelCreating(builder);
        }

        public DbSet<Student> Students { get; set; }
    }
}