﻿using Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace Core
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public DbSet<News> News { get; set; }
        public DbSet<Personal> Personals { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AppUser>()
                .HasOne(a => a.Personal)
                .WithOne(b => b.AppUser)
                .HasForeignKey<Personal>(b => b.UserId);
        }

        public static async Task CreateAppUserAccount(IServiceProvider serviceProvider,
            IConfiguration configuration, string configPath)
        {
            UserManager<AppUser> userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();
            RoleManager<IdentityRole> roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            string username = configuration[configPath + ":Name"];
            string email = configuration[configPath + ":Email"];
            string password = configuration[configPath + ":Password"];
            string role = configuration[configPath + ":Role"];

            if (await userManager.FindByNameAsync(username) == null)
            {
                if (await roleManager.FindByNameAsync(role) == null)
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }

                AppUser user = new AppUser
                {
                    UserName = username,
                    Email = email,
                    EmailConfirmed = true
                };

                IdentityResult result = await userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, role);
                }
            }
        }

        //public static async Task CreateAdminAccount(IServiceProvider serviceProvider, IConfiguration configuration)
        //{
        //    UserManager<AppUser> userManager =
        //    serviceProvider.GetRequiredService<UserManager<AppUser>>();
        //    RoleManager<IdentityRole> roleManager =
        //    serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        //    string username = configuration["Data:AdminUser:Name"];
        //    string email = configuration["Data:AdminUser:Email"];
        //    string password = configuration["Data:AdminUser:Password"];
        //    string role = configuration["Data:AdminUser:Role"];
        //    if (await userManager.FindByNameAsync(username) == null)
        //    {
        //        if (await roleManager.FindByNameAsync(role) == null)
        //        {
        //            await roleManager.CreateAsync(new IdentityRole(role));
        //        }
        //        AppUser user = new AppUser
        //        {
        //            UserName = username,
        //            Email = email
        //        };
        //        IdentityResult result = await userManager
        //        .CreateAsync(user, password);
        //        if (result.Succeeded)
        //        {
        //            await userManager.AddToRoleAsync(user, role);
        //        }
        //    }
        //}
    }
}