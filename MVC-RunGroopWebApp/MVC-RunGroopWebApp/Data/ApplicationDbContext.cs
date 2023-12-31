﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVC_RunGroopWebApp.Models;

namespace MVC_RunGroopWebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Race> Races { get; set; }

        public DbSet<Club> Clubs { get; set; }

        public DbSet<Address> Addresss { get; set; }
    }
}
