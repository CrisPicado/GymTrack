﻿using Application.Contexts;
using Domain.Clients;
using Domain.Coaches;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Contexts
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options) { }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Coach> Coaches { get; set; }

        public void Save()
        {
            this.SaveChanges();
        }

    }
}