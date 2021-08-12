using FastWork.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastWork.Data.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<CustomerServiceDbEntity>().HasKey(x => new { x.CustomerId, x.ServiceId });
            builder.Entity<SectionDbEntity>().HasQueryFilter(x => !x.IsDelete);
            builder.Entity<SubsectionDbEntity>().HasQueryFilter(x => !x.IsDelete);
            builder.Entity<ServiceProviderDbEntity>().HasQueryFilter(x => !x.IsDelete);
            builder.Entity<CustomerDbEntity>().HasQueryFilter(x => !x.IsDelete);
            builder.Entity<ServiceDbEntity>().HasQueryFilter(x => !x.IsDelete);
            builder.Entity<CustomerServiceDbEntity>().HasQueryFilter(x => !x.IsDelete);

        }

        public DbSet<CustomerDbEntity> Customers { get; set; }
        public DbSet<CustomerServiceDbEntity> CustomerServices { get; set; }
        public DbSet<SectionDbEntity> Sections { get; set; }
        public DbSet<ServiceDbEntity> Services { get; set; }
        public DbSet<ServiceProviderDbEntity> ServiceProviders { get; set; }
        public DbSet<SubsectionDbEntity> Subsections { get; set; }
        public DbSet<FileServiceDbEntity> Files { get; set; }
    }
}
