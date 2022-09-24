﻿using Freemer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freemer.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }

        public ApplicationDbContext()
        {
            Database.EnsureCreated();
        }

        public DbSet<Order> Order { get; set; }
        public DbSet<JobCategory> JobCategory { get; set; }

    }
}
