﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CarRentalManagement.Data;
using CarRentalManagement.Configuration.Entities;
using CarRentalManagement.Configurations.Entities;

namespace CarRentalManagement.Data
{
    public class CarRentalManagementContext(DbContextOptions<CarRentalManagementContext> options) : IdentityDbContext<CarRentalManagementUser>(options)
    {

        public DbSet<CarRentalManagement.Domains.Make> Make { get; set; } = default!;
        public DbSet<CarRentalManagement.Domains.Model> Model { get; set; } = default!;
        public DbSet<CarRentalManagement.Domains.Colour> Colour { get; set; } = default!;
        public DbSet<CarRentalManagement.Domains.Vehicle> Vehicle { get; set; } = default!;
        public DbSet<CarRentalManagement.Domains.Booking> Booking { get; set; } = default!;
        public DbSet<CarRentalManagement.Domains.Customer> Customer { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new ColourSeed());
            builder.ApplyConfiguration(new MakeSeed());
            builder.ApplyConfiguration(new ModelSeed());
            builder.ApplyConfiguration(new RoleSeed());
            builder.ApplyConfiguration(new UserRoleSeed());
            builder.ApplyConfiguration(new UserSeed());
        }
    }
}
